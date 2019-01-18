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
import { ErrorComponent } from "./error/error/error.component";
import { AuthGuard } from "./guard/auth.guard";
import { AuthService } from "./services/auth/auth.service";
import { ErrorService } from "./error/error.service";
import { ApiHelper } from "./helpers/api.helper";
import { routing } from './app.routing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatGridListModule, MatCardModule , MatCheckboxModule, MatListModule ,MatMenuModule, MatToolbarModule, MatIconModule, MatSidenavModule } from '@angular/material';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatMenuModule,
    MatIconModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    routing,
  ],
  declarations: [AppComponent , AppLayoutComponent, SiteLayoutComponent, SiteFooterComponent, LoginComponent, DashboardComponent, HomeComponent, AboutComponent, ProfileComponent, ErrorComponent],
  providers: [
    AuthGuard,
    AuthService,
    ApiHelper,
    ErrorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
