import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';
import { AdvertLink } from 'src/app/models/advertLink.model';
import { TypeOfAdvert } from 'src/app/models/advertType';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  userFlatRents: AdvertLink[] = [];
  typeFlatRent = TypeOfAdvert.flatRent;
  userFlatSale: AdvertLink[] = [];
  typeFlatSale = TypeOfAdvert.flatSale;
  userHouseRent: AdvertLink[] = [];
  typeHouseRent = TypeOfAdvert.houseRent;
  userHouseSale: AdvertLink[] = [];
  typeHouseSale = TypeOfAdvert.houseSale;
  constructor(
    private router: Router,
    private authService: AuthService,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.fetchUserAdverts();
  }

  private fetchUserAdverts() {
    this.advertService.getUserAdverts().subscribe(data => {
      for (const [key, value] of Object.entries(data.flatRent)) {
        this.userFlatRents.push({ id: key, name: value });
      }
      for (const [key, value] of Object.entries(data.flatSale)) {
        this.userFlatSale.push({ id: key, name: value });
      }
      for (const [key, value] of Object.entries(data.houseRent)) {
        this.userHouseRent.push({ id: key, name: value });
      }
      for (const [key, value] of Object.entries(data.houseSale)) {
        this.userHouseSale.push({ id: key, name: value });
      }
    });
  }

  logOut(){
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
}
