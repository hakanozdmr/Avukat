import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'app/model/User';
import { AuthService } from 'app/services/auth.service';
import { response } from 'express';
import {tap} from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../home/home.component.css']
})
export class LoginComponent implements OnInit {

  show:boolean = true;
  test : Date = new Date();
  focus;
  focus1;
  constructor(private httpClient:HttpClient , private router: Router,private authService:AuthService) { }


  ngOnInit(): void {
  }
  loginTry(email,password){

    this.authService.login(email.value,password.value).subscribe((data:any) => {
      console.log(data)
      if (data.role === 'users') {
      this.router.navigateByUrl(`user`);
      }
      else if (data.role === 'lawyers') {
        this.router.navigateByUrl(`avukat`);
        }
     });
  }
  loginUser(email,password): void {
    let login = {
      "email": email.value,
      "password": password.value
    }
    const url = 'https://localhost:7202/api/Auth/login';
    let data = this.httpClient.post<User>(url,login).pipe(
      tap( response => {
        // const user = new User(
        //   response.email,);
        console.log(response.email)
      }
        ))
    data.subscribe((data:any) => {
      if (data.role === 'users') {
      this.router.navigateByUrl(`users`);
      }
      else if (data.role === 'lawyers') {
        this.router.navigateByUrl(`avukat`);
        }
     });
   
    // Yönlendirme işlemleri burada yapılabilir.
  }

}
