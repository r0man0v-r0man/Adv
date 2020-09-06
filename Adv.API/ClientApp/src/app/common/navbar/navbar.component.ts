import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  switch = false;
  @Input() isVisible;
  constructor(
    public authService: AuthService
  ) { }

  ngOnInit(): void {
  }
  onSwitchChange(){
    this.switch = !this.switch;
  }
  onCloseMenu() {
    if(this.switch === true) {
      this.switch = !this.switch;
    }
  }
}