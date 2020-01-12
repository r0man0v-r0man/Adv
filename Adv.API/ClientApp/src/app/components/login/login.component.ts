import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';
import { AuthService } from 'src/app/services/auth.service';
import { Constants } from 'src/app/constants';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  loginUrl: string = Constants.login;
  loginForm: FormGroup;
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private route: Router) { }

  ngOnInit() {
    this.initializeLoginForm();
  }

  initializeLoginForm(){
    this.loginForm = this.formBuilder.group({
      userName:[null, [Validators.required, Validators.pattern('^(?=.*[a-zA-Z])[a-zA-Z0-9]+$')]],
      password:[null, [Validators.required]]
    })
  }

  signIn(user: UserModel){
    if(user){
      this.authService.login(this.loginUrl, user)
      .subscribe(response => { 
        if(response){
          this.route.navigate(['/']);
        }else{
          console.log(response);
        }
      })
    }
  }
}
