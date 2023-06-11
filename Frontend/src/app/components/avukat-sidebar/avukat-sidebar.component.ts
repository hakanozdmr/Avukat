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
    // { path: '/avukat/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    // { path: '/avukat/user-profile', title: 'User Profile',  icon:'person', class: '' },
    // { path: '/avukat/table-list', title: 'Table List',  icon:'content_paste', class: '' },
    // { path: '/avukat/typography', title: 'Typography',  icon:'library_books', class: '' },
    // { path: '/avukat/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/avukat/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    // { path: '/avukat/upgrade', title: 'Upgrade to PRO',  icon:'unarchive', class: 'active-pro' },
    // { path: '/avukat/ask-question', title: 'Soru Sor',  icon:'unarchive', class: '' },
    { path: '/avukat/questionList', title: 'Soru Listesi',  icon:'question_mark', class: '' },
    { path: '/avukat/digerAvukatlar', title: 'Diğer Avukatlar',  icon:'groups', class: '' },
];

@Component({
  selector: 'avukat-sidebar',
  templateUrl: './avukat-sidebar.component.html',
  styleUrls: ['./avukat-sidebar.component.css']
})
export class AvukatSidebarComponent implements OnInit {
  menuItems: any[];
  user;
  constructor(private router: Router,private authService:AuthService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem("lawyer"));
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  logout() {
    this.authService.logout("lawyer");
    this.router.navigateByUrl(`home`);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
