import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AvukatLayoutComponent } from './layouts/avukat-layout/avukat-layout.component';
import { AuthGuard } from './guards/auth-guard';
import { UserGuard } from './guards/user-guard';

const routes: Routes =[
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  }, {
    path: 'user',
    component: AdminLayoutComponent,
    canActivate:[UserGuard],
    children: [{
      path: '',
      loadChildren: () => import('./layouts/admin-layout/admin-layout.module').then(m => m.AdminLayoutModule)
    }]
  },
  {
    path: 'avukat',
    component: AvukatLayoutComponent,
    canActivate:[AuthGuard],
    children: [{
      path: '',
      loadChildren: () => import('./layouts/avukat-layout/avukat-layout.module').then(m => m.AvukatLayoutModule)
    }]
  },
  { path: 'home',           component: HomeComponent },
  { path: 'login',           component: LoginComponent },
  { path: 'register',           component: RegisterComponent },
  
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes,{
       useHash: false
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
