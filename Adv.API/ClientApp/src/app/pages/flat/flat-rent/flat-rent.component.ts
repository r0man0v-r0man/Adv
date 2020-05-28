import { Component, OnInit } from '@angular/core';
import { Params, ActivatedRoute } from '@angular/router';
import { AdvertService } from 'src/app/services/advert.service';
import { FlatRentModel } from 'src/app/models/flatRentModel';

@Component({
  selector: 'app-flat-rent',
  templateUrl: './flat-rent.component.html',
  styleUrls: ['./flat-rent.component.less']
})
export class FlatRentComponent implements OnInit {
  /** индентификатор объявления */
  advertId: number;
  /** объявление */
  advert: FlatRentModel;
  constructor(
    private route: ActivatedRoute,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.initPage();
  }

  /** инициализация страницы */
  private initPage(){
    this.route.params.subscribe((params: Params) => {
      this.advertId = params['id'];
      this.getAdvert(this.advertId);
    })
  }
  /** получение информации об объявлении */
  private getAdvert(id: number){
    this.advertService.getFlatRent(id).subscribe(response => {
      this.advert = response;
    });
  }
}
