import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  userId;
  userFlatRents;
  userFlatSale;
  userHouseRent;
  userHouseSale;
  constructor(
    private router: Router,
    private authService: AuthService,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.advertService.getUserAdverts().subscribe(data => {
      this.userFlatRents = data.flatRent;
      this.userFlatSale = data.flatSale;
      this.userHouseRent = data.houseRent;
      this.userHouseSale = data.houseSale;
    })
  }

  logOut(){
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
}
