import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/userModel';
import { UserNameValidators } from 'src/app/validators/userName.validators';
import { BadInput } from 'src/app/errors/badInput';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  
  registerForm: FormGroup;
  isLoading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initializeRegisiterForm();
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

  submitForm(registerUser: UserModel){
    if(registerUser){
      this.isLoadingSwitch();
      this.authService.registerUser(registerUser)
        .subscribe(response => {
          if(response){
            this.router.navigate(['/login']);
          }
        })

    }
    setTimeout(() => {
      this.isLoadingSwitch();
    }, 3000);
  }
  isLoadingSwitch(){
    this.isLoading = !this.isLoading;
  }
}
