import { Routes, RouterModule } from '@angular/router';



import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';


import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';

import { AuthGuard } from './guard/auth.guard';

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
      { path: 'profile', component: ProfileComponent }
    ],
    canActivate: [AuthGuard],
  },

  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
