﻿using Volo.Abp.EventBus;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace LINGYUN.Abp.Localization.Dynamic
{
    [DependsOn(
        typeof(AbpEventBusModule),
        typeof(AbpLocalizationModule))]
    public class AbpLocalizationDynamicModule : AbpModule
    {
    }
}
