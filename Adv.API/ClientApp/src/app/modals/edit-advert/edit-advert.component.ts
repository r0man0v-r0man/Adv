import { Component, OnInit } from '@angular/core';
import { UpdateAdvertService } from './service/update-advert.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit-advert',
  templateUrl: './edit-advert.component.html',
  styleUrls: ['./edit-advert.component.less'],
  providers: [
    UpdateAdvertService
  ]
})
export class EditAdvertComponent implements OnInit {
  advertId;
  advertType;
  form: FormGroup;
  constructor(
    private updateAdvertService: UpdateAdvertService
  ) { }

  ngOnInit(): void {
    this.updateAdvertService.initForm(this.advertId, this.advertType).subscribe(data => {
      if(data) this.form = data;
    })
  }
}
