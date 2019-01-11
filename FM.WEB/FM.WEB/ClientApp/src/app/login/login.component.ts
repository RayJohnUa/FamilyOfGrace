import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from "../services/auth/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  returnUrl: string;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService:AuthService ) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.authService.logout();
  }

  login(): void {
    this.authService.login(this.model.email, this.model.password);
    console.log(this.model);
  }
}
