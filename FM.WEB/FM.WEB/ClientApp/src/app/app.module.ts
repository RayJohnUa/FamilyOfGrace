import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppLayoutComponent } from './_layout/app-layout/app-layout.component';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { SiteFooterComponent } from './_layout/site-footer/site-footer.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ProfileComponent } from './profile/profile.component';
import { AuthGuard } from "./guard/auth.guard";
import { AuthService } from "./services/auth/auth.service";
import { routing } from './app.routing';

@NgModule({
  imports: [BrowserModule, HttpClientModule , FormsModule, routing],
  declarations: [AppComponent, AppLayoutComponent, SiteLayoutComponent, SiteFooterComponent, LoginComponent, DashboardComponent, HomeComponent, AboutComponent, ProfileComponent],
  providers: [
    AuthGuard,
    AuthService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
