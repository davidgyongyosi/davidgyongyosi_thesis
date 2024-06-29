export class CreateRoleDTO {
  roleName?: string;
}

export class RoleResponseDTO {
  id?: string;
  name?: string;
}
export class RoleAssingDTO {
  userId?: string;
  roleId?: string;
}
