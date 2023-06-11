import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output,Input } from '@angular/core';
import { Event as NavigationEvent } from "@angular/router";
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-question-detail',
  templateUrl: './question-detail.component.html',
  styleUrls: ['./question-detail.component.scss']
})
export class QuestionDetailComponent implements OnInit {
  constructor(private httpClient:HttpClient,private route: ActivatedRoute,private router: Router) { }
  question;
  answer;
  lawyers;
  questionId: number;
  isEditMode: boolean = false;

    toggleEditMode() {
        this.isEditMode = !this.isEditMode;
    }
  getAllUsers() { 
    const url = 'https://localhost:7202/api/Questions/User/1';
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.question = data;
     });
      return console.log(this.question);
  }
  otherLawyers(){
    const url = 'https://localhost:7202/api/Lawyers/ListOtherLawyers/'+this.question[0].lawyers.id;
      let data = this.httpClient.get(url)
      data.subscribe((data:any) => {
        this.lawyers = data;
       });
  }
  goToQuestionList(): void {
    this.router.navigateByUrl(`avukat/questionList`);
    // Yönlendirme işlemleri burada yapılabilir.
  }
  getAnswer(){
    this.route.params.subscribe(params => {
      this.questionId = +params['id'];
    });
      const url = 'https://localhost:7202/api/Questions/';
      let data = this.httpClient.get(url+this.questionId)
      data.subscribe((data:any) => {
        const lastIndex = data[0].answers.length - 1;
        this.answer = data[0].answers[lastIndex];
        console.log(this.answer);
      });
  }
  putQuestion(questionId,question,lawyersId,usersId){
    let putQuestion = {
      "id": questionId,
      "question": question,
      "lawyersId": lawyersId,
      "usersId": usersId
    }
    console.log(putQuestion);
    this.sendingNotification('top','center',`Soru Başka Avukata Gönderiliyor...`)
    let response = this.httpClient.put("https://localhost:7202/api/Questions",putQuestion).subscribe(data => this.showNotification('top','center',"Soru"));
   
    setTimeout(() => {
      this.router.navigateByUrl(`avukat/questionList`)
    },4000);
  }
  putAnswer(answerId,answer,questionId,usersId){
    let postAnswer = {
      "id": answerId,
      "answer": answer.value ,
      "questionsId": questionId,
      "usersId": usersId
    }
    console.log(postAnswer);
    this.sendingNotification('top','center',"Cevap Gönderiliyor...")
    let response = this.httpClient.put("https://localhost:7202/api/Answers",postAnswer).subscribe(data => this.showNotification('top','center',"Cevap"));
    
    setTimeout(() => {
      this.router.navigateByUrl(`avukat/questionList`)
    },4000);
  }
  postAnswer(answer,questionId,usersId){
    let postAnswer = {
      "answer": answer.value ,
      "questionsId": questionId,
      "usersId": usersId
    }
    this.sendingNotification('top','center',"Cevap Gönderiliyor...")
    let response = this.httpClient.post("https://localhost:7202/api/Answers",postAnswer).subscribe(data => this.showNotification('top','center',"Cevap"));
    
    setTimeout(() => {
      this.router.navigateByUrl(`avukat/questionList`)
    },4000);
  } 
 async ngOnInit() {
  // this.answer = "answer";
  this.getAnswer()
  this.route.params.subscribe(params => {
    this.questionId = +params['id'];
  });
    const url = 'https://localhost:7202/api/Questions/';
    let data = this.httpClient.get(url+this.questionId)
    data.subscribe((data:any) => {
      this.question = data;
      console.log(this.question);
     });
  }
  showNotification(from, align,string){
    // const type = ['','info','success','warning','danger'];
    const type = ['','info','success','warning','danger'];
    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "done",
        message: `<b>${string} Başarı İle Gönderildi</b> - 3 saniye sonra ana ekrana döneceksiniz`

    },{
        type: 'success',
        timer: 3000,
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
  sendingNotification(from, align , string){
    // const type = ['','info','success','warning','danger'];
    const type = ['','info','success','warning','danger'];
    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "notifications",
        message: `<b> ${string} </b>` 

    },{
        type: 'info',
        timer: 200,
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
