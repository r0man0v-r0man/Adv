import { Component, OnInit } from '@angular/core';
import { UpdateAdvertService } from './service/update-advert.service';

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
  form;
  constructor(
    private updateAdvertService: UpdateAdvertService
  ) { }

  ngOnInit(): void {
    this.updateAdvertService.initForm(this.advertId, this.advertType);
    this.updateAdvertService.form.subscribe(data => {
      this.form = data;
      console.log(this.form);
      
    })
  }

}
