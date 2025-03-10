<template>
  <div>
    <BasicTable @register="registerTable">
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'action'">
          <TableAction
            :stop-button-propagation="true"
            :actions="[
              {
                //auth: 'AbpOpenIddict.Authorizations.Update',
                label: L('Edit'),
                icon: 'ant-design:edit-outlined',
                onClick: handleEdit.bind(null, record),
              },
              {
                //auth: 'AbpOpenIddict.Authorizations.Delete',
                label: L('Delete'),
                color: 'error',
                icon: 'ant-design:delete-outlined',
                onClick: handleDelete.bind(null, record),
              },
            ]"
          />
        </template>
      </template>
    </BasicTable>
    <AuthorizationModal @register="registerModal" />
  </div>
</template>

<script lang="ts" setup>
  import { BasicTable, TableAction, useTable } from '/@/components/Table';
  import { getDataColumns } from '../datas/TableData';
  import { getSearchFormProps } from '../datas/ModalData';
  import { useModal } from '/@/components/Modal';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { useLocalization } from '/@/hooks/abp/useLocalization';
  import { getList, deleteById } from '/@/api/openiddict/authorizations';
  import { formatPagedRequest } from '/@/utils/http/abp/helper';
  import AuthorizationModal from './AuthorizationModal.vue';

  const { L } = useLocalization('AbpOpenIddict');
  const { createConfirm, createMessage } = useMessage();
  const [registerModal, { openModal }] = useModal();
  const [registerTable, { reload }] = useTable({
    rowKey: 'id',
    title: L('Authorizations'),
    api: getList,
    columns: getDataColumns(),
    beforeFetch: formatPagedRequest,
    pagination: true,
    striped: false,
    useSearchForm: true,
    showIndexColumn: false,
    showTableSetting: true,
    formConfig: getSearchFormProps(),
    bordered: true,
    canResize: true,
    immediate: true,
    actionColumn: {
      width: 150,
      title: L('Actions'),
      dataIndex: 'action',
    },
  });

  function handleEdit(record) {
    openModal(true, record);
  }

  function handleDelete(record) {
    createConfirm({
      iconType: 'warning',
      title: L('AreYouSure'),
      content: L('ItemWillBeDeletedMessage'),
      onOk: () => {
        return deleteById(record.key).then(() => {
          createMessage.success(L('SuccessfullyDeleted'));
          reload();
        });
      },
    });
  }
</script>
