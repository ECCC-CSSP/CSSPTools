import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AlertService, UserService, AuthenticationService } from '../services';
import { LoadLocales } from './register.locales';
import { RegisterText } from './register.interfaces';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
  })
export class RegisterComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;

    registerText = <RegisterText>{};

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private alertService: AlertService
    ) {
        // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.FillLocales();       

        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            username: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        this.userService.register(this.registerForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Registration successful', true);
                    this.router.navigate(['/login']);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }

    FillLocales() {
        LoadLocales();
        this.registerText.Register = $localize`:@@register.Register:`;
        this.registerText.FirstName = $localize`:@@register.FirstName:`;
        this.registerText.FirstNameIsRequired = $localize`:@@register.FirstNameIsRequired:`;
        this.registerText.LastName = $localize`:@@register.LastName:`;
        this.registerText.LastNameIsRequired = $localize`:@@register.LastNameIsRequired:`;
        this.registerText.UserName = $localize`:@@register.UserName:`;
        this.registerText.UserNameIsRequired = $localize`:@@register.UserNameIsRequired:`;
        this.registerText.Password = $localize`:@@register.Password:`;
        this.registerText.PasswordIsRequired = $localize`:@@register.PasswordIsRequired:`;
        this.registerText.PasswordMustBeAtLeast6Characters = $localize`:@@register.PasswordMustBeAtLeast6Characters:`;
        this.registerText.Cancel = $localize`:@@register.Cancel:`;
        this.registerText.Locale = $localize.locale;
    }
}
