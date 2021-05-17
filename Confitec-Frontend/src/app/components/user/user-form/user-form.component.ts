import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { KeyValuePair } from 'src/app/models/key-value-pair';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private _userService: UserService,
    private _activatedRoute: ActivatedRoute, private _router: Router, private _messageService: MessageService) { }

  userForm: FormGroup;
  educationLevelList: KeyValuePair[];

  ngOnInit(): void {

    this.userForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required]],
      birthdate: ['', Validators.required],
      educationLevel: ['0', [Validators.min(1)]]
    });

    this.getAllEducationLevel();

    const userId = this._activatedRoute.snapshot.paramMap.get("id");
    if (userId)
      this.editUserFillForm(parseInt(userId));
  }

  public getAllEducationLevel() {
    this._userService.getAllEducationLevel().subscribe((response) => {
      this.educationLevelList = response;
    });
  }

  public handleSubmitUser() {

    if (!this.userForm.valid)
      return;

    this.userForm.get("educationLevel").setValue(parseInt(this.userForm.get("educationLevel").value))

    if (this.userForm.get("id").value) {

      this._userService.updateUser(this.userForm.value).subscribe(() => {
        this._messageService.add({ severity: 'success', summary: "Sucesso", detail: "Usuário alterado" });
        this._router.navigate(['users']);
      },
        (error) => {
          var errorObj = error.error.errors;
          const errorList = Object.keys(errorObj).map(x => errorObj[x]);

          errorList.map(x => {
            this._messageService.add({ severity: 'error', summary: "Erro", detail: x[0] });
          });
        });
    }
    else {

      this._userService.createUser(this.userForm.value).subscribe(() => {
        this._messageService.add({ severity: 'success', summary: "Sucesso", detail: "Usuário adicionado" });
        this._router.navigate(['users']);
      },
        (error) => {
          var errorObj = error.error.errors;
          const errorList = Object.keys(errorObj).map(x => errorObj[x]);

          errorList.map(x => {
            this._messageService.add({ severity: 'error', summary: "Erro", detail: x[0] });
          });
        });
    }
  }

  editUserFillForm(id: number) {
    this._userService.getUserById(id).subscribe((response) => {
      this.userForm.setValue({
        id: response.id,
        name: response.name,
        lastName: response.lastName,
        email: response.email,
        birthdate: new Date(response.birthdate),
        educationLevel: response.educationLevel
      });
    });
  }
}
