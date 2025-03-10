<template>
  <div>
    <BasicTable @register="registerTable">
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'url'">
          <Tag :color="httpStatusCodeColor(record.httpStatusCode)">{{ record.httpStatusCode }}</Tag>
          <Tag style="margin-left: 5px" :color="httpMethodColor(record.httpMethod)">{{
            record.httpMethod
          }}</Tag>
          <span style="margin-left: 5px">{{ record.url }}</span>
        </template>
        <template v-else-if="column.key === 'action'">
          <TableAction
            :actions="[
              {
                auth: 'AbpAuditing.AuditLog',
                color: 'success',
                label: L('ShowLogDialog'),
                icon: 'ant-design:search-outlined',
                onClick: handleShow.bind(null, record),
              },
              {
                auth: 'AbpAuditing.AuditLog.Delete',
                color: 'error',
                label: L('Delete'),
                icon: 'ant-design:delete-outlined',
                onClick: handleDelete.bind(null, record),
              },
            ]"
          />
        </template>
      </template>
    </BasicTable>
    <AuditLogModal @register="registerModal" />
  </div>
</template>

<script lang="ts" setup>
  import { Tag } from 'ant-design-vue';
  import { useLocalization } from '/@/hooks/abp/useLocalization';
  import { BasicTable, TableAction, useTable } from '/@/components/Table';
  import { getDataColumns } from './TableData';
  import { getSearchFormSchemas } from './ModalData';
  import { useModal } from '/@/components/Modal';
  import { useAuditLog } from '../hooks/useAuditLog';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { deleteById, getList } from '/@/api/auditing/auditLog';
  import { formatPagedRequest } from '/@/utils/http/abp/helper';
  import AuditLogModal from './AuditLogModal.vue';

  const { createMessage, createConfirm } = useMessage();
  const { L } = useLocalization('AbpAuditLogging');
  const [registerTable, { reload }] = useTable({
    rowKey: 'id',
    title: L('AuditLog'),
    columns: getDataColumns(),
    api: getList,
    beforeFetch: formatPagedRequest,
    pagination: true,
    striped: false,
    useSearchForm: true,
    showTableSetting: true,
    bordered: true,
    showIndexColumn: false,
    canResize: false,
    immediate: true,
    formConfig: getSearchFormSchemas(),
    scroll: { x: 'max-content', y: '100%' },
    actionColumn: {
      width: 180,
      title: L('Actions'),
      dataIndex: 'action',
    },
  });
  const [registerModal, { openModal }] = useModal();
  const { httpMethodColor, httpStatusCodeColor } = useAuditLog();

  function handleShow(record) {
    openModal(true, record, true);
  }

  function handleDelete(record) {
    createConfirm({
      iconType: 'warning',
      title: L('AreYouSure'),
      content: L('ItemWillBeDeletedMessage'),
      okCancel: true,
      onOk: () => {
        return deleteById(record.id).then(() => {
          createMessage.success(L('SuccessfullyDeleted'));
          reload();
        });
      },
    });
  }
</script>
