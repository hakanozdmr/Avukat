import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { TableListComponent } from '../../table-list/table-list.component';
import { TypographyComponent } from '../../typography/typography.component';
import { IconsComponent } from '../../icons/icons.component';
import { NotificationsComponent } from '../../notifications/notifications.component';
import { UpgradeComponent } from '../../upgrade/upgrade.component';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatRippleModule} from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import { AskQuestionComponent } from 'app/ask-question/ask-question.component';
import { DetailQuestionComponent } from 'app/detail-question/detail-question.component';
import { ListQuestionComponent } from 'app/list-question/list-question.component';
import { AvukatLayoutRoutes } from './avukat-layout.routing';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionDetailComponent } from './detail-question/question-detail.component';
import { LawyersListComponent } from './lawyers-list/lawyers-list.component';


@NgModule({
  declarations: [
    QuestionListComponent,
    QuestionDetailComponent,
    LawyersListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(AvukatLayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
  ]
})
export class AvukatLayoutModule { }
