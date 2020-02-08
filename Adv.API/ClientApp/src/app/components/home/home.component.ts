import { Component, OnInit } from '@angular/core';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  constructor(
    private navService: NavbarService,
    private footerService: FooterService

  ) { }

  ngOnInit() {
    this.navService.show();
    this.footerService.show();
  }

}
