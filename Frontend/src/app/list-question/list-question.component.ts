import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
import { take, tap } from 'rxjs';
declare var $: any;
@Component({
  selector: 'app-list-question',
  templateUrl: './list-question.component.html',
  styleUrls: ['./list-question.component.scss'],
  providers: [DatePipe]
})
export class ListQuestionComponent implements OnInit {

  constructor(private httpClient:HttpClient , private router: Router,private authService:AuthService,private datePipe: DatePipe) { }
  questions:any[] = [];
  totalQuestions;
  answeredQuestions;
  user;
  show;
  openModal() {
    if(this.show != false) {
    $('#myModal').modal('show'); // Modalı açmak için jQuery kullanımı
    }
  }
  formatDate(date: Date) {
     return this.datePipe.transform(date, 'dd MMMM YYYY HH:mm', 'tr-TR');
   
  }
  closeModel(){
    if(this.show === true) {
      this.show=false;
    }else if (this.show === false){
      this.show=true;
    }
   console.log(this.show)
  }
  getAllUsers() { 
    const url = 'https://localhost:7202/api/Questions/User/1';
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
  this.router.navigateByUrl(`user/detail-question/${questionId}`);
  // Yönlendirme işlemleri burada yapılabilir.
}
QuestionS(){
  const url = `https://localhost:7202/api/Questions/User/${this.user.id}`;
  let data = this.httpClient.get(url)
  data.subscribe((data:any) => {
    this.questions = data;
   });
}
AnsweredQuestionS(){
  const url = 'https://localhost:7202/api/Questions/User/Answered/'+this.user.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
      console.log(this.questions)
     });
}
DansweredQuestionS(){
  const url = 'https://localhost:7202/api/Questions/User/Danswered/'+this.user.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
      console.log(this.questions)
     });
}

 async ngOnInit() {
    this.authService.user.pipe(
      take(1),
      tap(user => console.log(user)
    ))
    this.user = JSON.parse(localStorage.getItem("user"));
    const url = `https://localhost:7202/api/Questions/User/${this.user.id}`;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.questions = data;
      if (this.questions.length > 0) {
        this.answeredQuestions = this.questions.filter(question => question.state === true).length;
      }
     });
     this.openModal();
     const currentDate = new Date('0001-01-01T00:00:00');
      const formattedDate = currentDate.toLocaleString('tr-TR', {  day: 'numeric',month: 'short', hour: 'numeric', minute: 'numeric', second: 'numeric' });
      console.log(formattedDate); // Örnek çıktı: "Jan 1, 12:00:00 AM"
  }

}
