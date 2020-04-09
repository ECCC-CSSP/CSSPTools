import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from './login.service';
import { LoginModel } from './login.models';
import { LoadLocalesLogin } from './login.locale';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    public loginService: LoginService,
    public userService: UserService,
  ) {
  }

  ngOnInit() {
    LoadLocalesLogin(this.loginService);
    this.loginForm = this.formBuilder.group({
      LoginEmail: [this.loginService.loginModel$.value?.LoginEmail, Validators.required],
      Password: [this.loginService.loginModel$.value?.Password, Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.loginService.UpdateLogin(<LoginModel>{ Language: $localize.locale, returnUrl: this.returnUrl });
    //this.userService.UpdateUser(null);

    if (this.userService.userModel$.value.Id) {
      this.router.navigate(['/']);
    }
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {

    this.userService.UpdateUser(<UserModel>{ Submitted: true });

    if (this.loginForm.invalid) {
      this.userService.UpdateUser(null);
      return;
    }

    this.loginService.UpdateLogin(<LoginModel>{ LoginEmail: this.f.LoginEmail.value })
    this.userService.Login(this.f.LoginEmail.value, this.f.Password.value, this.router,  $localize.locale);
  }
}
