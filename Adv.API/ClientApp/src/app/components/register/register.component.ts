import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/UserModel';
import { Router } from '@angular/router';
import { UserNameValidators } from 'src/app/validators/userName.validators';
import { AuthService } from 'src/app/services/auth.service';
import { UserWarning } from 'src/app/app-errors/userWarning';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';

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
    private router: Router,
    private navService: NavbarService,
    private footerService: FooterService

    ) { }

  ngOnInit() {
    this.navService.hide();
    this.footerService.hide();
    this.initializeRegisiterForm();
  }

  submitForm(registerUser: UserModel){
    if(registerUser){
      this.isLoadingSwitch();
      this.authService.registerUser(registerUser)
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
