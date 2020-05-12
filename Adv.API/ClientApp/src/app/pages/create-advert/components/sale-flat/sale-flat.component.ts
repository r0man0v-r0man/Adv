import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { FlatSaleModel } from 'src/app/models/flatSaleModel';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'sale-flat',
  templateUrl: './sale-flat.component.html',
  styleUrls: ['./sale-flat.component.less']
})
export class SaleFlatComponent implements OnInit {
  /** форма добавления объявления */
  saleFlatForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.initForm();
  }
  /** инициализация формы */
  private initForm(){
    this.saleFlatForm = this.formBuilder.group({
      userId:[ this.authService.currentUser.sub,[Validators.required]],
      isActive: [ true ],
    })
  }
  /** создание объявления */
  submitForm(){
    const saleFlatModel: FlatSaleModel = { ...this.saleFlatForm.value }
    this.advertService.addFlatSale(saleFlatModel);
  }
}
