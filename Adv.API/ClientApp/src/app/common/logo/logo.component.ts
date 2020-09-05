import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-logo',
  templateUrl: './logo.component.html',
  styleUrls: ['./logo.component.less']
})
export class LogoComponent implements OnInit {
  @Input() isMenu;
  width = '25%';
  constructor() { }

  ngOnInit(): void {
    console.log(this.isMenu);
    
  }

}
