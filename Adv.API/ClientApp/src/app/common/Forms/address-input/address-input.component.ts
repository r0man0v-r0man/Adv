import {Component, Input, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {SuggestService} from '../../../services/suggest.service';

@Component({
  selector: 'app-address-input',
  templateUrl: './address-input.component.html',
  styleUrls: ['./address-input.component.less'],
  providers: [
    SuggestService
  ]
})
export class AddressInputComponent implements OnInit {
  @Input() group: FormGroup;
  constructor(
    public suggestService: SuggestService
  ) { }

  ngOnInit(): void {
  }

}
