import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    // { path: '/user/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    // { path: '/user/user-profile', title: 'User Profile',  icon:'person', class: '' },
    // { path: '/user/table-list', title: 'Table List',  icon:'content_paste', class: '' },
    // { path: '/user/typography', title: 'Typography',  icon:'library_books', class: '' },
    // { path: '/user/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/user/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    // { path: '/user/upgrade', title: 'Upgrade to PRO',  icon:'unarchive', class: 'active-pro' },
    { path: '/user/ask-question', title: 'Soru Sor',  icon:'add', class: '' },
    { path: '/user/list-question', title: 'Sorularım',  icon:'question_mark', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor(private router: Router,private authService:AuthService) { }
  user;
  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem("user"));
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
  logout() {
    this.authService.logout("user");
    this.router.navigateByUrl(`home`);
  }
}
