import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/UserModel';
import { RegisterService } from 'src/app/services/register.service';
import { Constants } from 'src/app/constants';
import { Router } from '@angular/router';
import { UserNameValidators } from 'src/app/validators/userName.validators';
import { AuthService } from 'src/app/services/auth.service';
import { UserWarning } from 'src/app/app-errors/userWarning';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {

  registerUrl: string = Constants.registerUser;
  registerForm: FormGroup;
  isLoading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private registerService: RegisterService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.initializeRegisiterForm();
  }

  submitForm(registerUser: UserModel){
    if(registerUser){
      this.isLoadingSwitch();
      this.registerService.registerUser(this.registerUrl, registerUser)
        .subscribe(response => {
          if(response){
            this.router.navigate(['/login']);
          }
        },
        (error)=>{
          setTimeout(() => {
            this.isLoadingSwitch();
          }, 3000);
          throw new UserWarning(error.error);
        })
    }
  }
  
  initializeRegisiterForm(){
    this.registerForm = this.formBuilder.group({
      userName:
        [null, 
          {
          validators: [Validators.required, Validators.pattern('^(?=.*[a-zA-Z])[a-zA-Z0-9]+$')],
          asyncValidators: [UserNameValidators.duplicated(this.authService)],
          updateOn: 'blur'
          } 
        ],
      password:[null, [Validators.required]]
    })
  }

  isLoadingSwitch(){
    this.isLoading = !this.isLoading;
  }

}
