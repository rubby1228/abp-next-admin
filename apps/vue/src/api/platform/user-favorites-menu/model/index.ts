import { AuditedEntityDto, EntityDto, IHasConcurrencyStamp } from '/@/api/model/baseModel';

export interface UserFavoriteMenuDto extends AuditedEntityDto, EntityDto<string> {
  menuId: string;
  userId: string;
  aliasName?: string;
  color?: string;
  framework: string;
  name: string;
  displayName: string;
  path?: string;
  icon?: string;
}

interface UserFavoriteMenuCreateOrUpdateDto {
  menuId: string;
  color?: string;
  aliasName?: string;
  icon?: string;
}

export interface UserFavoriteMenuCreateDto extends UserFavoriteMenuCreateOrUpdateDto {
  framework: string;
}

export interface UserFavoriteMenuUpdateDto extends UserFavoriteMenuCreateOrUpdateDto, IHasConcurrencyStamp {
}

