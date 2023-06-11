import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  // styleUrls: ['./css/style.css','./css/slick.css','./css/responsive.css','./css/normalize.css',
  // './css/nice-select.css','./css/meanmenu.css','./css/jquery-ui.css','./css/animate.min.css',]
  styleUrls: ['./home.component.css',]
})
export class HomeComponent implements OnInit {
  imagePath: "images/loading.gif";
  logoPath: "assets/img/favicon.png";
  constructor() { }
  
  ngOnInit(): void {
  }
 
}
