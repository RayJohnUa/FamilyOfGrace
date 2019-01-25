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
import { MatInputModule, MatButtonModule , MatFormFieldModule , MatPaginatorModule , MatTableModule, MatGridListModule, MatCardModule , MatCheckboxModule, MatListModule ,MatMenuModule, MatToolbarModule, MatIconModule, MatSidenavModule } from '@angular/material';
import { PersonsComponent } from './persons/persons.component';
import { MailingComponent } from './mailing/mailing.component';
import { TokenInterceptor } from './services/token.interceptor';
import { PersonService } from './services/person/person.service';
import { Ng2SmartTableModule } from 'ng2-smart-table';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    Ng2SmartTableModule,
    MatInputModule,
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
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    routing,
  ],
  declarations: [AppComponent, MailingComponent , PersonsComponent , AppLayoutComponent, SiteLayoutComponent, SiteFooterComponent, LoginComponent, DashboardComponent, HomeComponent, AboutComponent, ProfileComponent, ErrorComponent],
  providers: [
    AuthGuard,
    AuthService,
    PersonService,
    ApiHelper,
    ErrorService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
