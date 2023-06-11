import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output,Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;
@Component({
  selector: 'app-detail-question',
  templateUrl: './detail-question.component.html',
  styleUrls: ['./detail-question.component.scss']
})
export class DetailQuestionComponent implements OnInit {
  constructor(private httpClient:HttpClient,private route: ActivatedRoute,private router:Router) { }
  question;
  answer;
  otherLawyers;
  rating = 0;
  questionId: number;
  getAllUsers() { 
    const url = 'https://localhost:7202/api/Questions/User/1';
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.question = data[0];
     });
      return console.log(this.question);
  }
click(data) {
  data
}
getOtherLawyers(){
  const url = 'https://localhost:7202/api/Lawyers/ListOtherLawyers/'+this.question.lawyers.id;
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      console.log(data);
      this.otherLawyers = data;
      console.log(this.otherLawyers);
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
    this.router.navigateByUrl(`user/list-question`)
  },4000);
}
getAnswer(id){
  const url = 'https://localhost:7202/api/Answers/Question/';
    let data = this.httpClient.get(url+id)
    data.subscribe((data:any) => {
      const lastIndex = data.length - 1;
      this.answer = data[lastIndex];
      console.log(this.answer);
     });
}
putAnswer(answerId,rating:number,answer,questionsId,usersId){
  let putAnswer = { 
    "id": answerId,
    "rating": rating,
    "answer": answer,
    "questionsId": questionsId,
    "usersId": usersId
    
  }
  console.log(putAnswer);
  this.sendingNotification('top','center',`Cevap Değerlendiriliyor...`)
  let response = this.httpClient.put("https://localhost:7202/api/Answers",putAnswer).subscribe(data => this.showNotification('top','center',"Cevap"));
}
takeRating(rating:number){
  this.rating = rating;
  console.log(rating);
}
sendRating(answerId,rating:number,answer,questionsId,usersId){
  let putAnswer = { 
    "id": answerId,
    "rating": rating,
    "answer": answer,
    "questionsId": questionsId,
    "usersId": usersId
    
  }
  this.rating = rating;
  console.log(putAnswer);
}
 async ngOnInit() {
  // this.answer = "answer";
  this.route.params.subscribe(params => {
    this.questionId = +params['id'];
  });
    const url = 'https://localhost:7202/api/Questions/';
    let data = this.httpClient.get(url+this.questionId)
    data.subscribe((data:any) => {
      this.question = data[0];
        
        console.log(this.question);
     });
     this.getAnswer(this.questionId);
  }
  showNotification(from, align,string){
    // const type = ['','info','success','warning','danger'];
    const type = ['','info','success','warning','danger'];
    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "done",
        message: `<b>${string} Başarı İle Değerlendirildi</b>`

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
