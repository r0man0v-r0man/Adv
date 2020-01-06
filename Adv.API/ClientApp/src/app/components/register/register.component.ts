import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/UserModel';
import { RegisterService } from 'src/app/services/register.service';
import { Constants } from 'src/app/constants';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  registerUrl: string = Constants.registerUser;
  registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private registerService: RegisterService) { }

  ngOnInit() {
    this.initializeRegisiterForm();
  }

  submitForm(registerUser: UserModel){
    if(registerUser){
      this.registerService.registerUser(this.registerUrl, registerUser)
        .subscribe(response => {
          console.log(response);
        })
    }
  }
  initializeRegisiterForm(){
    this.registerForm = this.formBuilder.group({
      userName:[null, [Validators.required]],
      password:[null, [Validators.required]]
    })
  }
}
