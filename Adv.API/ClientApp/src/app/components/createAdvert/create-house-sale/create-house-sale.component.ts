import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FileService } from 'src/app/services/file.service';
import { AuthService } from 'src/app/services/auth.service';
import { StreetsService } from 'src/app/services/streets.service';
import { CompressorService } from 'src/app/services/compressor.service';

@Component({
  selector: 'app-create-house-sale',
  templateUrl: './create-house-sale.component.html',
  styleUrls: ['./create-house-sale.component.less']
})
export class CreateHouseSaleComponent implements OnInit {
  /** форма добавления объявления - дом продать */
  houseSaleForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private fileService: FileService,
    private authService: AuthService,
    private streetService: StreetsService,
    public compressor: CompressorService
  ) { }

  ngOnInit() {
    this.initHouseSaleForm();
  }
  initHouseSaleForm(){
    this.houseSaleForm = this.formBuilder.group({
      userId: [this.authService.currentUser.sub, [Validators.required]]
    })
  }
}
