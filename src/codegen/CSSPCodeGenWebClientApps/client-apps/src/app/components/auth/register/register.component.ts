import { Component, OnInit } from '@angular/core';
import { RegisterModel } from './register.models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { LoadLocalesRegister } from './register.locale';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerModel: RegisterModel;
  registerForm: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private registerService: RegisterService,
  ) {
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      FirstName: ['', Validators.required],
      Initial: [''],
      LastName: ['', Validators.required],
      LoginEmail: ['', Validators.required],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      ConfirmPassword: ['', Validators.required]
    });
    LoadLocalesRegister(this.registerService);

    this.registerModel = this.registerService.registerModel$.getValue();
    this.registerService.UpdateRegister({ ...this.registerModel, ...{ Language: $localize.locale } });
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {

    this.registerService.UpdateRegister({...this.registerModel, ...{ Submitted: true }});
    this.registerModel = this.registerService.registerModel$.getValue();

    if (this.registerForm.invalid) {
      return;
    }

    this.registerService.UpdateRegister({ ...this.registerModel, ...{ Loading: true } });
    this.registerModel = this.registerService.registerModel$.getValue();
    this.registerService.Register(this.f);
  }
}
