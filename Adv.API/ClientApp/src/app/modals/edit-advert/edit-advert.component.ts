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
  updateModel;
  constructor(
    private updateAdvertService: UpdateAdvertService
  ) { }

  ngOnInit(): void {
    console.log(this.form);
    
  }

  get form() {
    return this.updateAdvertService.form;
  }
}
