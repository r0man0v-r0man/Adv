import {Component, Input, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';

@Component({
  selector: 'app-address-input',
  templateUrl: './address-input.component.html',
  styleUrls: ['./address-input.component.less']
})
export class AddressInputComponent implements OnInit {
  @Input() group: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

}
