import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { KeyValuePair } from 'src/app/models/key-value-pair';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  constructor(private _userService: UserService, private _router: Router, private _messageService: MessageService,
    private _confirmationService: ConfirmationService) { }

  public userList: User[];
  public educationLevelList: KeyValuePair[];

  ngOnInit(): void {
    this.getAllEducationLevel()
    this.getAllUser()
  }

  public getAllEducationLevel() {
    this._userService.getAllEducationLevel().subscribe((response) => {
      this.educationLevelList = response;
    });
  }
  public getAllUser() {
    this._userService.getAllUser().subscribe((response) => {
      this.userList = response;
      if (this.educationLevelList){
        this.userList.map(x => {
          x.educationLevelDescription = this.educationLevelList.find(y => y.Value === x.educationLevel).Key;
        })
      }
    });
  }

  handleEditUser(id: number) {
    this._router.navigate([`user/${id}`]);
  }

  handleRemoveUser(id: number) {
    this._confirmationService.confirm({
      message: 'Tem certeza que deseja excluir esse usuário?',
      accept: () => {
        this._userService.deleteUser(id).subscribe((response) => {
          this._messageService.add({ severity: 'success', summary: "Sucesso", detail: "Usuário excluído" });
          this.getAllUser();
        },
          (error) => {
            var errorObj = error.error.errors;
            const errorList = Object.keys(errorObj).map(x => errorObj[x]);

            errorList.map(x => {
              this._messageService.add({ severity: 'error', summary: "Erro", detail: x[0] });
            });
          });
      }
    });
  }

}
