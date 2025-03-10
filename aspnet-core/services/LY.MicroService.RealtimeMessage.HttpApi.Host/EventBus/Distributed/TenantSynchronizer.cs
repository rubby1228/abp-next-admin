﻿using LINGYUN.Abp.Data.DbMigrator;
using LINGYUN.Abp.MessageService.Localization;
using LINGYUN.Abp.MultiTenancy;
using LINGYUN.Abp.Notifications;
using LINGYUN.Abp.RealTime.Localization;
using LY.MicroService.RealtimeMessage.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace LY.MicroService.RealtimeMessage.EventBus.Distributed
{
    public class TenantSynchronizer : IDistributedEventHandler<CreateEventData>, ITransientDependency
    {
        protected ILogger<TenantSynchronizer> Logger { get; }
        protected ICurrentTenant CurrentTenant { get; }
        protected IUnitOfWorkManager UnitOfWorkManager { get; }
        protected IDbSchemaMigrator DbSchemaMigrator { get; }
        protected INotificationSender NotificationSender { get; }
        protected INotificationSubscriptionManager NotificationSubscriptionManager { get; }

        public TenantSynchronizer(
            ICurrentTenant currentTenant,
            IDbSchemaMigrator dbSchemaMigrator,
            IUnitOfWorkManager unitOfWorkManager,
            INotificationSender notificationSender,
            INotificationSubscriptionManager notificationSubscriptionManager,
            ILogger<TenantSynchronizer> logger)
        {
            Logger = logger;

            CurrentTenant = currentTenant;
            DbSchemaMigrator = dbSchemaMigrator;
            UnitOfWorkManager = unitOfWorkManager;

            NotificationSender = notificationSender;
            NotificationSubscriptionManager = notificationSubscriptionManager;
        }

        public async Task HandleEventAsync(CreateEventData eventData)
        {
            using (var unitOfWork = UnitOfWorkManager.Begin())
            {
                using (CurrentTenant.Change(eventData.Id, eventData.Name))
                {
                    Logger.LogInformation("Migrating the new tenant database with messages...");
                    // 迁移租户数据
                    await DbSchemaMigrator.MigrateAsync<RealtimeMessageMigrationsDbContext>(
                        (connectionString, builder) =>
                        {
                            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                            return new RealtimeMessageMigrationsDbContext(builder.Options);
                        });
                    Logger.LogInformation("Migrated the new tenant database with messages.");

                    await SendNotificationAsync(eventData);

                    await unitOfWork.CompleteAsync();
                }
            }
        }

        private async Task SendNotificationAsync(CreateEventData eventData)
        {
            try
            {
                var tenantAdminUserIdentifier = new UserIdentifier(eventData.AdminUserId, eventData.AdminEmailAddress);

                // 租户管理员订阅事件
                await NotificationSubscriptionManager
                    .SubscribeAsync(
                        eventData.Id,
                        tenantAdminUserIdentifier,
                        TenantNotificationNames.NewTenantRegistered);

                Logger.LogInformation("publish new tenant notification..");
                await NotificationSender.SendNofiterAsync(
                    TenantNotificationNames.NewTenantRegistered,
                    new NotificationTemplate(
                        TenantNotificationNames.NewTenantRegistered,
                        formUser: eventData.AdminEmailAddress,
                        data: new Dictionary<string, object>
                        {
                            { "name", eventData.Name },
                            { "email", eventData.AdminEmailAddress },
                            { "id", eventData.Id },
                        }),
                    tenantAdminUserIdentifier,
                    eventData.Id,
                    NotificationSeverity.Success);

                Logger.LogInformation("tenant administrator subscribes to new tenant events..");
            }
            catch(Exception ex)
            {
                Logger.LogWarning(ex, "Failed to send the tenant initialization notification.");
            }
        }
    }
}
