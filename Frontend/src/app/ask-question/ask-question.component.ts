import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;
@Component({
  selector: 'app-ask-question',
  templateUrl: './ask-question.component.html',
  styleUrls: ['./ask-question.component.css']
})
export class AskQuestionComponent implements OnInit {
  categories;
  lawyers;
  cardVisible = false;
  cardId;
  forId;
  showDefaultImage: boolean = false;
  user;
  constructor(private httpClient:HttpClient,private route: ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem("user"));
    this.getCategories();
    this.getasd();
  }
  handleImageError() {
    this.showDefaultImage = true;
  }
  postQuestion(question,lawyersId,usersId){
    let postQ = {
      "question": question.value ,
      "lawyersId": lawyersId,
      "usersId": usersId
    }
    this.sendingNotification('top','center')
    let response = this.httpClient.post("https://localhost:7202/api/Questions", postQ).subscribe(data => {
      this.showNotification('top', 'center');
      setTimeout(() => {
        this.router.navigateByUrl(`user/list-question`);
      }, 4000);
    });
    // this.showNotification('bottom','center')
    
  } 
  getCategories(){
    const url = 'https://localhost:7202/api/Categories';
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.categories = data.data;
      console.log(this.categories);
     });
  }
  getRating(){
    const url = 'https://localhost:7202/api/Categories';
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      this.categories = data.data;
      console.log(this.categories);
     });
  }
  getasd(){
    const url = 'https://localhost:7202/api/Lawyers/Rating';
    let data = this.httpClient.get(url)
    data.subscribe((data:any) => {
      console.log(data);
     });
  }
  getLawyers(id){
    console.log(id);
    const url = `https://localhost:7202/api/Categories/${id}/lawyers`;
    let data = this.httpClient.get(url)
    console.log(data);
    data.subscribe((data:any) => {
      console.log(data);
      this.lawyers = data;
      console.log(this.lawyers);
     });
  }
  sendingNotification(from, align){
    // const type = ['','info','success','warning','danger'];
    const type = ['','info','success','warning','danger'];
    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "notifications",
        message: "<b>Soru Gönderiliyor...</b> "

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
  showCard(id: number) {  
    
        if (this.cardVisible === false) {
            this.cardVisible = true;
        } else if (this.cardVisible === true && this.cardId === id) {
            this.cardVisible = false;
        }
        this.cardId = id;
  }
  showNotification(from, align){
    const type = ['','info','success','warning','danger'];

    const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "done",
        message: "Soru Başarı İle Gönderildi</b> - 3 saniye sonra ana ekrana döneceksiniz"

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
