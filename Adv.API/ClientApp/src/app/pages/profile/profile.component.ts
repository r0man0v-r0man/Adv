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
  data;
  userFlatRents;
  userFlatSales;
  typeFlatRent = TypeOfAdvert.flatRent;
  typeFlatSale = TypeOfAdvert.flatSale;
  typeHouseRent = TypeOfAdvert.houseRent;
  typeHouseSale = TypeOfAdvert.houseSale;
  constructor(
    private router: Router,
    private authService: AuthService,
    private advertService: AdvertService
  ) { }
  private getUserFlatRents() {
    const list: AdvertLink[] = [];
    for (const [key, value] of Object.entries(this.data.flatRent)) {
        list.push({ id: key, name: value });
      }
      this.userFlatRents = list;
    return this.userFlatRents;
  }
  private getUserFlatSale() {
    const list: AdvertLink[] = [];
    for (const [key, value] of Object.entries(this.data.flatSale)) {
        list.push({ id: key, name: value });
      }
      this.userFlatSales = list;
    return this.userFlatSales;
  }
  get userHouseRent() {
    const list: AdvertLink[] = [];
    for (const [key, value] of Object.entries(this.data.houseRent)) {
        list.push({ id: key, name: value });
      }
    return list;
  }
  get userHouseSale() {
    const list: AdvertLink[] = [];
    for (const [key, value] of Object.entries(this.data.houseSale)) {
        list.push({ id: key, name: value });
      }
    return list;
  }
  ngOnInit(): void {
    this.fetchUserAdverts();
  }

  private fetchUserAdverts() {
    this.advertService.getUserAdverts().subscribe(data => {
      if (data) this.data = data;
      this.getUserFlatRents();
      this.getUserFlatSale();
    });
  }

  logOut(){
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
}
