import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';
import { AuthService } from 'src/app/services/auth.service';
import { Constants } from 'src/app/constants';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserWarning } from 'src/app/app-errors/userWarning';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  isLoading: boolean = false;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
    ) { }

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
      this.isLoadingSwitch();
      this.authService.login(user)
      .subscribe(response => { 
        if(response){
          let returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
          this.router.navigate([returnUrl || '/']);
        }
      },
      (error)=>{
        setTimeout(() => {
          this.isLoadingSwitch();
        }, 5000);
        throw new UserWarning(error.error);
      })
    }
  }
  isLoadingSwitch(){
    this.isLoading = !this.isLoading;
  }
}
