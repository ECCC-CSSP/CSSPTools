import { Component, OnInit } from '@angular/core';
import { RegisterModel } from './register.models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from './register.service';

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
    private router: Router,
    private registerService: RegisterService,
  ) {
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      FirstName: ['', Validators.required],
      Intial: [''],
      LastName: ['', Validators.required],
      LoginEmail: ['', Validators.required],
      Password: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.registerModel = this.registerService.registerModel$.getValue();
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {

    this.registerService.Update({...this.registerModel, ...{ Submitted: true }});
    this.registerModel = this.registerService.registerModel$.getValue();

    if (this.registerForm.invalid) {
      return;
    }

    this.registerService.Update({ ...this.registerModel, ...{ Loading: true } });
    this.registerModel = this.registerService.registerModel$.getValue();
    this.registerService.Register(this.f);
  }


}
