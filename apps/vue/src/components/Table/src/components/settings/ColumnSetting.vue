<template>
  <Tooltip placement="top">
    <template #title>
      <span>{{ t('component.table.settingColumn') }}</span>
    </template>
    <Popover
      placement="bottomLeft"
      trigger="click"
      @visible-change="handleVisibleChange"
      :overlayClassName="`${prefixCls}__cloumn-list`"
      :getPopupContainer="getPopupContainer"
    >
      <template #title>
        <div :class="`${prefixCls}__popover-title`">
          <Checkbox
            :indeterminate="indeterminate"
            v-model:checked="state.checkAll"
            @change="onCheckAllChange"
          >
            {{ t('component.table.settingColumnShow') }}
          </Checkbox>

          <Checkbox v-model:checked="checkIndex" @change="handleIndexCheckChange">
            {{ t('component.table.settingIndexColumnShow') }}
          </Checkbox>

          <Checkbox
            v-model:checked="checkSelect"
            @change="handleSelectCheckChange"
            :disabled="!defaultRowSelection"
          >
            {{ t('component.table.settingSelectColumnShow') }}
          </Checkbox>

          <Checkbox v-model:checked="checkDrag" @change="handleDragChange">
            {{ t('component.table.settingDragColumnShow') }}
          </Checkbox>

          <a-button size="small" type="link" @click="reset">
            {{ t('common.resetText') }}
          </a-button>
        </div>
      </template>

      <template #content>
        <ScrollContainer>
          <CheckboxGroup v-model:value="state.checkedList" @change="onChange" ref="columnListRef">
            <template v-for="item in plainOptions" :key="item.value">
              <div :class="`${prefixCls}__check-item`" v-if="!('ifShow' in item && !item.ifShow)">
                <DragOutlined class="table-column-drag-icon" />
                <Checkbox :value="item.value">
                  {{ item.label }}
                </Checkbox>

                <Tooltip
                  placement="bottomLeft"
                  :mouseLeaveDelay="0.4"
                  :getPopupContainer="getPopupContainer"
                >
                  <template #title>
                    {{ t('component.table.settingFixedLeft') }}
                  </template>
                  <Icon
                    icon="line-md:arrow-align-left"
                    :class="[
                      `${prefixCls}__fixed-left`,
                      {
                        active: item.fixed === 'left',
                        disabled: !state.checkedList.includes(item.value),
                      },
                    ]"
                    @click="handleColumnFixed(item, 'left')"
                  />
                </Tooltip>
                <Divider type="vertical" />
                <Tooltip
                  placement="bottomLeft"
                  :mouseLeaveDelay="0.4"
                  :getPopupContainer="getPopupContainer"
                >
                  <template #title>
                    {{ t('component.table.settingFixedRight') }}
                  </template>
                  <Icon
                    icon="line-md:arrow-align-left"
                    :class="[
                      `${prefixCls}__fixed-right`,
                      {
                        active: item.fixed === 'right',
                        disabled: !state.checkedList.includes(item.value),
                      },
                    ]"
                    @click="handleColumnFixed(item, 'right')"
                  />
                </Tooltip>
              </div>
            </template>
          </CheckboxGroup>
        </ScrollContainer>
      </template>
      <SettingOutlined />
    </Popover>
  </Tooltip>
</template>
<script lang="ts" setup>
  import type { BasicColumn, ColumnChangeParam } from '../../types/table';
  import {
    useAttrs,
    ref,
    reactive,
    watchEffect,
    nextTick,
    unref,
    computed,
  } from 'vue';
  import { Tooltip, Popover, Checkbox, Divider } from 'ant-design-vue';
  import type { CheckboxChangeEvent } from 'ant-design-vue/lib/checkbox/interface';
  import { SettingOutlined, DragOutlined } from '@ant-design/icons-vue';
  import { Icon } from '/@/components/Icon';
  import { ScrollContainer } from '/@/components/Container';
  import { useI18n } from '/@/hooks/web/useI18n';
  import { useTableContext } from '../../hooks/useTableContext';
  import { useDesign } from '/@/hooks/web/useDesign';
  // import { useSortable } from '/@/hooks/web/useSortable';
  import { isFunction, isNullAndUnDef, isNumber } from '/@/utils/is';
  import { getPopupContainer as getParentContainer } from '/@/utils';
  import { cloneDeep, omit } from 'lodash-es';
  import Sortablejs from 'sortablejs';
  import type Sortable from 'sortablejs';

  interface State {
    checkAll: boolean;
    isInit?: boolean;
    checkedList: string[];
    defaultCheckList: string[];
  }

  interface Options {
    label: string;
    value: string;
    fixed?: boolean | 'left' | 'right';
  }

  const CheckboxGroup = Checkbox.Group;
  const emits = defineEmits(['columns-change']);

  const { t } = useI18n();
  const table = useTableContext();

  const defaultRowSelection = omit(table.getRowSelection(), 'selectedRowKeys');
  let inited = false;

  const cachePlainOptions = ref<Options[]>([]);
  const plainOptions = ref<Options[] | any>([]);

  const plainSortOptions = ref<Options[]>([]);

  const columnListRef = ref<ComponentRef>(null);

  const state = reactive<State>({
    checkAll: true,
    checkedList: [],
    defaultCheckList: [],
  });

  const checkIndex = ref(false);
  const checkSelect = ref(false);
  const checkDrag = ref(false);

  const { prefixCls } = useDesign('basic-column-setting');

  const getValues = computed(() => {
    return unref(table?.getBindValues) || {};
  });

  watchEffect(() => {
    setTimeout(() => {
      const columns = table.getColumns();
      if (columns.length && !state.isInit) {
        init();
      }
    }, 10);
  });

  watchEffect(() => {
    const values = unref(getValues);
    checkIndex.value = !!values.showIndexColumn;
    checkSelect.value = !!values.rowSelection;
  });

  function getColumns() {
    const ret: Options[] = [];
    table.getColumns({ ignoreIndex: true, ignoreAction: true }).forEach((item) => {
      ret.push({
        label: (item.title as string) || (item.customTitle as string),
        value: (item.dataIndex || item.title) as string,
        ...item,
      });
    });
    return ret;
  }

  function init() {
    const columns = getColumns();

    const checkList = table
      .getColumns({ ignoreAction: true, ignoreIndex: true })
      .map((item) => {
        if (item.defaultHidden) {
          return '';
        }
        return item.dataIndex || item.title;
      })
      .filter(Boolean) as string[];

    if (!plainOptions.value.length) {
      plainOptions.value = columns;
      plainSortOptions.value = columns;
      cachePlainOptions.value = columns;
      state.defaultCheckList = checkList;
    } else {
      // const fixedColumns = columns.filter((item) =>
      //   Reflect.has(item, 'fixed')
      // ) as BasicColumn[];

      unref(plainOptions).forEach((item: BasicColumn) => {
        const findItem = columns.find((col: BasicColumn) => col.dataIndex === item.dataIndex);
        if (findItem) {
          item.fixed = findItem.fixed;
        }
      });
    }
    state.isInit = true;
    state.checkedList = checkList;
  }

  // checkAll change
  function onCheckAllChange(e: CheckboxChangeEvent) {
    const checkList = plainOptions.value.map((item) => item.value);
    if (e.target.checked) {
      state.checkedList = checkList;
      setColumns(checkList);
    } else {
      state.checkedList = [];
      setColumns([]);
    }
  }

  const indeterminate = computed(() => {
    const len = plainOptions.value.length;
    let checkedLen = state.checkedList.length;
    unref(checkIndex) && checkedLen--;
    return checkedLen > 0 && checkedLen < len;
  });

  // Trigger when check/uncheck a column
  function onChange(checkedList: string[]) {
    const len = plainSortOptions.value.length;
    state.checkAll = checkedList.length === len;
    const sortList = unref(plainSortOptions).map((item) => item.value);
    checkedList.sort((prev, next) => {
      return sortList.indexOf(prev) - sortList.indexOf(next);
    });
    setColumns(checkedList);
  }

  let sortable: Sortable;
  let sortableOrder: string[] = [];
  // reset columns
  function reset() {
    state.checkedList = [...state.defaultCheckList];
    state.checkAll = true;
    plainOptions.value = unref(cachePlainOptions);
    plainSortOptions.value = unref(cachePlainOptions);
    setColumns(table.getCacheColumns());
    sortable.sort(sortableOrder);
  }

  // Open the pop-up window for drag and drop initialization
  function handleVisibleChange() {
    if (inited) return;
    nextTick(() => {
      const columnListEl = unref(columnListRef);
      if (!columnListEl) return;
      const el = columnListEl.$el as any;
      if (!el) return;
      // Drag and drop sort
      sortable = Sortablejs.create(unref(el), {
        animation: 500,
        delay: 400,
        delayOnTouchOnly: true,
        handle: '.table-column-drag-icon ',
        onEnd: (evt) => {
          const { oldIndex, newIndex } = evt;
          if (isNullAndUnDef(oldIndex) || isNullAndUnDef(newIndex) || oldIndex === newIndex) {
            return;
          }
          // Sort column
          const columns = cloneDeep(plainSortOptions.value);

          if (oldIndex > newIndex) {
            columns.splice(newIndex, 0, columns[oldIndex]);
            columns.splice(oldIndex + 1, 1);
          } else {
            columns.splice(newIndex + 1, 0, columns[oldIndex]);
            columns.splice(oldIndex, 1);
          }

          plainSortOptions.value = columns;
          // fix: 修复ColumnSetting中默认隐藏列拖拽排序错误的bug (#1931)
          // https://github.com/vbenjs/vue-vben-admin/commit/50468e9581c93e95df21447bec30b6148541c46b
          setColumns(
            columns
              .map((col: Options) => col.value)
              .filter((value: string) => state.checkedList.includes(value)),
          );
        },
      });
      // 记录原始order 序列
      sortableOrder = sortable.toArray();
      inited = true;
    });
  }

  // Control whether the serial number column is displayed
  function handleIndexCheckChange(e: CheckboxChangeEvent) {
    table.setProps({
      showIndexColumn: e.target.checked,
    });
  }

  // Control whether the check box is displayed
  function handleSelectCheckChange(e: CheckboxChangeEvent) {
    table.setProps({
      rowSelection: e.target.checked ? defaultRowSelection : undefined,
    });
  }

  function handleDragChange(e: CheckboxChangeEvent) {
    const columns = getColumns() as BasicColumn[];
    columns.forEach((col) => {
      if (isNumber(col.width)) {
        col.resizable = e.target.checked;
      }
    });
    setColumns(columns);
  }

  function handleColumnFixed(item: BasicColumn, fixed?: 'left' | 'right') {
    if (!state.checkedList.includes(item.dataIndex as string)) return;

    const columns = getColumns() as BasicColumn[];
    const isFixed = item.fixed === fixed ? false : fixed;
    const index = columns.findIndex((col) => col.dataIndex === item.dataIndex);
    if (index !== -1) {
      columns[index].fixed = isFixed;
    }
    item.fixed = isFixed;

    if (isFixed && !item.width) {
      item.width = 100;
    }
    table.setCacheColumnsByField?.(item.dataIndex as string, { fixed: isFixed });
    setColumns(columns);
  }

  function setColumns(columns: BasicColumn[] | string[]) {
    table.setColumns(columns);
    const data: ColumnChangeParam[] = unref(plainSortOptions).map((col) => {
      const visible =
        columns.findIndex(
          (c: BasicColumn | string) =>
            c === col.value || (typeof c !== 'string' && c.dataIndex === col.value),
        ) !== -1;
      return { dataIndex: col.value, fixed: col.fixed, visible };
    });

    emits('columns-change', data);
  }

  function getPopupContainer() {
    const attrs = useAttrs();
    return isFunction(attrs.getPopupContainer)
      ? attrs.getPopupContainer()
      : getParentContainer();
  }
</script>
<style lang="less">
  @prefix-cls: ~'@{namespace}-basic-column-setting';

  .table-column-drag-icon {
    margin: 0 5px;
    cursor: move;
  }

  .@{prefix-cls} {
    &__popover-title {
      position: relative;
      display: flex;
      align-items: center;
      justify-content: space-between;
    }

    &__check-item {
      display: flex;
      align-items: center;
      min-width: 100%;
      padding: 4px 16px 8px 0;

      .ant-checkbox-wrapper {
        width: 100%;

        &:hover {
          color: @primary-color;
        }
      }
    }

    &__fixed-left,
    &__fixed-right {
      color: rgb(0 0 0 / 45%);
      cursor: pointer;

      &.active,
      &:hover {
        color: @primary-color;
      }

      &.disabled {
        color: @disabled-color;
        cursor: not-allowed;
      }
    }

    &__fixed-right {
      transform: rotate(180deg);
    }

    &__cloumn-list {
      svg {
        width: 1em !important;
        height: 1em !important;
      }

      .ant-popover-inner-content {
        // max-height: 360px;
        padding-right: 0;
        padding-left: 0;
        // overflow: auto;
      }

      .ant-checkbox-group {
        width: 100%;
        min-width: 260px;
        // flex-wrap: wrap;
      }

      .scrollbar {
        height: 220px;
      }
    }
  }
</style>
