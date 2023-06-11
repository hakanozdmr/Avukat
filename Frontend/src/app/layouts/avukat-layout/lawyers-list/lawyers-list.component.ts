import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lawyers-list',
  templateUrl: './lawyers-list.component.html',
  styleUrls: ['./lawyers-list.component.scss']
})
export class LawyersListComponent implements OnInit {

  constructor(private httpClient:HttpClient , private router: Router) { }
  user;
  lawyers;
  cardVisible = false;
  cardId;
  ngOnInit(): void {
     this.user = JSON.parse(localStorage.getItem("lawyer"))
    const url = 'https://localhost:7202/api/Lawyers/ListOtherLawyers/'+this.user.authorizedUser.id;
    let data = this.httpClient.get(url)
    console.log(data);
    data.subscribe((data:any) => {
      this.lawyers = data;
      console.log(this.lawyers);
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

}
