import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from './login.service';
import { LoginModel } from './login.models';
import { LoadLocalesLogin } from './login.locale';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/user.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  returnUrl: string;
  sub: Subscription;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    public loginService: LoginService,
    public userService: UserService,
  ) {
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {

    this.userService.UpdateUser(<UserModel>{ Submitted: true });

    if (this.loginForm.invalid) {
      this.userService.UpdateUser(null);
      return;
    }

    this.loginService.UpdateLogin(<LoginModel>{ LoginEmail: this.f.LoginEmail.value })
    this.sub = this.userService.Login(this.f.LoginEmail.value, this.f.Password.value, this.router, $localize.locale, this.returnUrl).subscribe();
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

  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }

}
