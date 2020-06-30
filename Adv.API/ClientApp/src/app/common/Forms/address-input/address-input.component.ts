import {Component, Input, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {YandexGeocoderService} from '../../../services/yandex-geocoder.service';

@Component({
  selector: 'app-address-input',
  templateUrl: './address-input.component.html',
  styleUrls: ['./address-input.component.less'],
  providers: [
    YandexGeocoderService
  ]
})
export class AddressInputComponent implements OnInit {
  @Input() group: FormGroup;
  constructor(
    public yandexGeocoderService: YandexGeocoderService
  ) { }

  ngOnInit(): void {
  }

}
