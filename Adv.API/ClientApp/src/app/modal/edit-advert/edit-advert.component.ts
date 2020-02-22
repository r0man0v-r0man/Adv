import { Component, OnInit, Input } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DescriptionValidators } from 'src/app/validators/description.validators';

@Component({
  selector: 'app-edit-advert',
  templateUrl: './edit-advert.component.html',
  styleUrls: ['./edit-advert.component.less']
})
export class EditAdvertComponent implements OnInit {

  @Input() flat: FlatModel;
  editForm: FormGroup;

  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.initEditForm();
  }

  initEditForm(){
    this.editForm = this.formBuilder.group({
      description: [this.flat.description,  [DescriptionValidators.notOnlySpace]],
      id: [this.flat.id],
      price: [this.flat.price, [Validators.required]],
      phoneNumberPrefix:[this.flat.phoneNumberPrefix],
      phoneNumber: [ this.flat.phoneNumber, [Validators.required, Validators.maxLength(9), Validators.minLength(9), Validators.pattern("[0-9]*")]]
    })
  }

}
