import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Subject, tap } from 'rxjs';
import { User } from 'app/model/User';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
    private url = 'https://localhost:7202/api/Auth/login';
    user = new BehaviorSubject<User | null >(null);
    constructor(private http: HttpClient){

    }
    login(email: string, password: string) {
        return this.http.post<User>(this.url, { email, password }).pipe(
          tap(response => {
            this.handleUser(response)
          })
        );
    }
    logout(role){
      this.user.next(null);
      localStorage.removeItem(`${role}`);
    }
    autoLogin(){
        if(localStorage.getItem("user") == null){
            return
        }
        const user =JSON.parse(localStorage.getItem("user")) 
        const loadedUser = new User(user.email,
            user.password,
            user.id,
            user.token,
            user.role,
            user.expirationTime,
            user.authorizedUser)
        if(loadedUser.token){
            this.user.next(loadedUser);
        }
    }
    handleUser(response){
        const user: User = {
            email: response.email,
            password: response.password,
            id: response.id,
            token: response.token,
            role: response.role,
            expirationTime: response.expirationTime,
            authorizedUser: response.authorizedUser
          };
          console.log(user);
          this.user.next(user);
          if(user.role ==="users"){
            localStorage.setItem('user', JSON.stringify(user));
          }
          else if (user.role ==="lawyers"){
            localStorage.setItem('lawyer', JSON.stringify(user));
          }
          
    }
}