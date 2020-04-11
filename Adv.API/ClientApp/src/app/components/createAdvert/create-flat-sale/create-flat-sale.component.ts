import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-create-flat-sale',
  templateUrl: './create-flat-sale.component.html',
  styleUrls: ['./create-flat-sale.component.less']
})
export class CreateFlatSaleComponent implements OnInit {

  flatSaleForm: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.initFlatSaleForm();
  }
  initFlatSaleForm(){
    this.flatSaleForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]]
    })
  }
}
