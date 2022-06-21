import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserLogin } from '../user/interfaces/user-login.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  signIn(user: UserLogin){
    return this.http.post(`${environment.APIURL}/user/login`,user);
  }

  isSessionExist(): boolean{
      return localStorage.getItem('user') != null;
  }

  layout(){
      localStorage.removeItem('user');
  }
}
