import { Component } from '@angular/core';
import { UserDetailDTO } from '../../models/user';
import { AuthService } from '../../services/auth/auth.service';
import { RoleService } from '../../services/role/role.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent {
  tableData: UserDetailDTO[] = [];

  constructor(private authService: AuthService, private roleService: RoleService) { 
    this.authService.getUsers().subscribe({
      next: (data) => {
        this.tableData = data;
      },
      error: (e) => {
        console.error(e);
      }
    });

  }

  ngOnInit(): void {
  }

  deleteUser(id: string) {
      this.authService.deleteUser(id).subscribe({
        next: (data) => {
          this.tableData = this.tableData.filter(user => user.userId !== id);
        },
        error: (e) => {
          console.error(e);
        }
      })
    }
}

