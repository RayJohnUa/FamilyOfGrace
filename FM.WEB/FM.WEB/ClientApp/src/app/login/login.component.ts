import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from "../services/auth/auth.service";
import { ErrorService } from '../error/error.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  error: any = {
    password: false,
    email : false
  };
  returnUrl: string;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private errorService:ErrorService) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.authService.logout();
  }

  private isValid(): boolean {
    if (!this.model.email) {
      this.error.email = true;
      return false;
    } else {
      this.error.email = false;
    }
    if (!this.model.password) {
      this.error.password = true;
      return false;
    } else {
      this.error.password = false;
    }
    return true;
  }

  login(): void {
    if (this.isValid()) {
      this.authService.login(this.model.email, this.model.password).subscribe(
        data => {
          localStorage.setItem('logedUser', data.toString());
          this.router.navigate(["admin/dashboard"]);
        },
        err => {
          this.errorService.pushStringError(err.error);
        }
      );
    }
  }
}
