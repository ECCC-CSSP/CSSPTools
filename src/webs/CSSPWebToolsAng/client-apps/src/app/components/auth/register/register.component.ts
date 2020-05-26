import { Component, OnInit, OnDestroy } from '@angular/core';
import { RegisterModel } from './register.models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { LoadLocalesRegister } from './register.locale';
import { UserService } from 'src/app/services/user.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  registerModel: RegisterModel;
  registerForm: FormGroup;
  sub: Subscription;

  constructor(
    private formBuilder: FormBuilder,
    private registerService: RegisterService
  ) {
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {

    this.registerService.UpdateRegister({...this.registerModel, ...{ Working: true }});
    this.registerModel = this.registerService.registerModel$.getValue();

    if (this.registerForm.invalid) {
      return;
    }

    this.registerService.UpdateRegister({ ...this.registerModel, ...{ Working: true } });
    this.registerModel = this.registerService.registerModel$.getValue();
    this.sub = this.registerService.Register(this.f).subscribe();
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      FirstName: ['', Validators.required, Validators.maxLength(100)],
      Initial: ['', Validators.maxLength(50)],
      LastName: ['', Validators.required, Validators.maxLength(100)],
      LoginEmail: ['', Validators.required, Validators.maxLength(200)],
      Password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]],
      ConfirmPassword: ['', Validators.required, Validators.maxLength(50)]
    });
    LoadLocalesRegister(this.registerService);

    this.registerModel = this.registerService.registerModel$.getValue();
    this.registerService.UpdateRegister({ ...this.registerModel, ...{ Language: $localize.locale } });
  }

  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }

}
