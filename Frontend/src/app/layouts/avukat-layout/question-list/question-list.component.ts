import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
declare var $: any;
@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.scss']
})
export class QuestionListComponent implements OnInit {

  constructor(private httpClient:HttpClient , private router: Router,private authService:AuthService) { }
  questions: {};
  lawyers;
  countedQuestions;
   test: Date = new Date();
  authedUser;
  postQuestion(){

    this.showNotification('bottom','right')
  }
  getAllUsers() { 
    const url = 'https://localhost:7202/api/Questions/Lawyers/1';
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
     });
      return console.log(this.questions);
  }
  showNotification(from, align){
    const type = ['','info','success','warning','danger'];

    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "notifications",
        message: "Welcome to <b>Material Dashboard</b> - a beautiful freebie for every web developer."

    },{
        type: type[color],
        timer: 4000,
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
click(data) {
  data
}
goToQuestionDetail(questionId: number): void {
  this.router.navigateByUrl(`avukat/detail-question/${questionId}`);
  // Yönlendirme işlemleri burada yapılabilir.
}
CountedQuestionS(){
  const url = 'https://localhost:7202/api/Questions/Lawyers/Count/'+this.authedUser.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.countedQuestions = data;
      console.log(this.countedQuestions)
     });
}
AnsweredQuestionS(){
  const url = 'https://localhost:7202/api/Questions/Lawyers/Answered/'+this.authedUser.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
      console.log(this.questions)
     });
}
QuestionS(){
  const url = 'https://localhost:7202/api/Questions/Lawyers/'+this.authedUser.id;
  let data = this.httpClient.get(url)
  data.subscribe((data:any) => {
    this.questions = data;
   });
}
DansweredQuestionS(){
  const url = 'https://localhost:7202/api/Questions/Lawyers/Danswered/'+this.authedUser.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
      console.log(this.questions)
     });
}
otherLawyers(){
  const url = 'https://localhost:7202/api/Lawyers/ListOtherLawyers/'+this.authedUser.id;
    let data = this.httpClient.get(url)
    console.log(data);
    data.subscribe((data:any) => {
      this.lawyers = data;
      console.log(this.lawyers);
     });
}
 async ngOnInit() {
  let user = JSON.parse(localStorage.getItem("lawyer"))
  this.authedUser = user.authorizedUser;
  this.authService.user.subscribe(user => {
    this.authedUser = user.authorizedUser
  })
    const url = 'https://localhost:7202/api/Questions/Lawyers/'+this.authedUser.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
     });
     this.CountedQuestionS()
  }

}
