import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from './login.service';
import { LoginModel } from './login.models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent implements OnInit {
  loginModel: LoginModel;
  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private loginService: LoginService,
  ) {
    // redirect to home if already logged in
    if (this.loginService.loginModel$.getValue()) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.loginModel = this.loginService.loginModel$.getValue();
    this.loginForm = this.formBuilder.group({
      LoginEmail: ['', Validators.required],
      Password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.loginService.Update({...this.loginModel, ...{ returnUrl: this.returnUrl }});
    this.loginModel = this.loginService.loginModel$.getValue();
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {

    this.loginService.Update({...this.loginModel, ...{ Submitted: true }});
    this.loginModel = this.loginService.loginModel$.getValue();

    if (this.loginForm.invalid) {
      return;
    }

    this.loginService.Update({...this.loginModel, ...{ Loading: true }});
    this.loginModel = this.loginService.loginModel$.getValue();
    this.loginService.Login(this.f);
  }
}