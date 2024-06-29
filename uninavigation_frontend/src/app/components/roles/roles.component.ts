import { Component } from '@angular/core';
import { UserDetailDTO } from '../../models/user';
import { RoleService } from '../../services/role/role.service';
import { AuthService } from '../../services/auth/auth.service';
import { NotificationService } from '../../services/notification/notification.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.scss',
})
export class RolesComponent {
  users: UserDetailDTO[] = [];
  roles: any;
  selectedRole: any;
  selectedUser: any;
  newRole!: string;
  loading = false;

  constructor(
    private authService: AuthService,
    private roleService: RoleService,
    private notification: NotificationService
  ) {
    this.loadUsers();
    this.loadRoles();
  }

  loadRoles() {
    this.roleService.getRoles().subscribe({
      next: (data) => {
        this.roles = data;
      },
      error: (e) => {
        this.notification.error(e.error);
      },
    });
  }

  loadUsers() {
    this.authService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
      },
      error: (error) => {
        this.notification.error(error.error);
      },
    });
  }

  createRole(roleName: string) {
    this.roleService.createRole(roleName).subscribe({
      next: (response) => {
        this.notification.success(response.message);
      },
      error: (error) => {
        this.notification.error(error.error);
      },
      complete: () => {
        this.newRole = '';
        this.loadRoles();
      },
    });
  }

  deleteRole(id: string) {
    this.roleService.deleteRole(id).subscribe({
      next: (response) => {
        this.notification.success(response.message);
      },
      error: (error) => {
        this.notification.error(error.error);
      },
      complete: () => {
        this.loadRoles();
      },
    });
  }

  assignRole() {
    this.roleService
      .assignRole(this.selectedUser, this.selectedRole)
      .subscribe({
        next: (response) => {
          this.notification.success(response.message);
        },
        error: (error) => {
          this.notification.error(error.error);
        },
        complete: () => {
          this.selectedRole = null;
          this.selectedUser = null;
        },
      });
  }
}
