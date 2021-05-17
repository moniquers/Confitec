import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';
import { KeyValuePair } from 'src/app/models/key-value-pair';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private _httpClient: HttpClient) { }

  private _url = `${environment.apiUrl}/User`

  getAllEducationLevel() {
    return this._httpClient.get<KeyValuePair[]>(`${this._url}/EducationLevel`);
  }

  getAllUser() {
    return this._httpClient.get<User[]>(`${this._url}`);
  }

  getUserById(id: number) {
    return this._httpClient.get<User>(`${this._url}/${id}`);
  }

  createUser(userForm: User): Observable<any> {
    return this._httpClient.post(`${this._url}`, userForm);
  }

  updateUser(userForm: User): Observable<any> {
    return this._httpClient.put(`${this._url}/${userForm.id}`, userForm);
  }

  deleteUser(id: number): Observable<any> {
    return this._httpClient.delete(`${this._url}/${id}`);
  }
}
