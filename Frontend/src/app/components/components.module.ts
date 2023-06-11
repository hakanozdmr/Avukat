import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { AvukatSidebarComponent } from './avukat-sidebar/avukat-sidebar.component';
import { NgxLoadingComponent } from './ngx-loading/ngx-loading.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    AvukatSidebarComponent,
    NgxLoadingComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    AvukatSidebarComponent,
    NgxLoadingComponent
  ]
})
export class ComponentsModule { }
