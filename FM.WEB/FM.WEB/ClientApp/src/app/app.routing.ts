import { Routes, RouterModule } from '@angular/router';



import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';


import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { AuthGuard } from './guard/auth.guard';
import { PersonsComponent } from './persons/persons.component';
import { MailingComponent } from './mailing/mailing.component';
import { MailingSingleComponent } from './mailing-single/mailing-single.component';

const appRoutes: Routes = [

  //Site routes goes here 
  {
    path: '',
    component: SiteLayoutComponent,
    children: [
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent },
      { path: 'test/:id', component: AboutComponent }
    ]
  },

  // App routes goes here here
  {
    path: 'admin',
    component: AppLayoutComponent,
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'persons', component: PersonsComponent },
      { path: 'mailing', component: MailingComponent },
      { path: 'mailing/details/:id', component: MailingSingleComponent }
    ],
    canActivate: [AuthGuard],
  },

  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
