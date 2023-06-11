import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
declare var $: any;
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../home/home.component.css']
})
export class RegisterComponent implements OnInit {
  test : Date = new Date();
  focus;
  focus1;
  focus2;
  constructor(private httpClient:HttpClient , private router: Router,private authService:AuthService) { }

  ngOnInit(): void {
  }
  registerTry(username,email,password){
    let postQ = {
      "userName": username.value,
      "email": email.value,
      "password": password.value,
    }
    this.sendingNotification('top','center')
    let response = this.httpClient.post("https://localhost:7202/api/Users", postQ).subscribe(data => {
      this.showNotification('top', 'center');
      setTimeout(() => {
        this.router.navigateByUrl(`home`);
      }, 4000);
    });
    // this.showNotification('bottom','center')
    
  } 
  sendingNotification(from, align){
    // const type = ['','info','success','warning','danger'];
    const type = ['','info','success','warning','danger'];
    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "notifications",
        message: "<b>Kayıt Olunuyor...</b> "

    },{
        type: 'info',
        timer: 200,
        placement: {
            from: from,
            align: align
        },
        template: '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
          '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
          '<i class="material-icons" data-notify="icon">notifications</i> ' +
          '<span data-notify="title">{1}</span> ' +
          '<span data-notify="message">{2}</span>' +
          '<div class="progress" data-notify="progressbar">' +
            '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
          '</div>' +
          '<a href="{3}" target="{4}" data-notify="url"></a>' +
        '</div>'
    });
  }
  showNotification(from, align){
    const type = ['','info','success','warning','danger'];

    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "done",
        message: "Başarı İle Kayıt Olundu</b> - 3 saniye sonra ana ekrana döneceksiniz"

    },{
        type: "success",
        timer: 2000,
        placement: {
            from: from,
            align: align
        },
        template: '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
          '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
          '<i class="material-icons" data-notify="icon">done</i> ' +
          '<span data-notify="title">{1}</span> ' +
          '<span data-notify="message">{2}</span>' +
          '<div class="progress" data-notify="progressbar">' +
            '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
          '</div>' +
          '<a href="{3}" target="{4}" data-notify="url"></a>' +
        '</div>'
    });
}
}
