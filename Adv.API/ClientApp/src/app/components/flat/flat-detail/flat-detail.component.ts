import { Component, OnInit } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute } from '@angular/router';
import { Constants } from 'src/app/constants';

@Component({
  selector: 'app-flat-detail',
  templateUrl: './flat-detail.component.html',
  styleUrls: ['./flat-detail.component.less']
})

export class FlatDetailComponent implements OnInit {
  flatUrl:string = Constants.flat;
  flat: FlatModel;

  constructor(
    private _flatService:FlatService,
    private _route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getFlatIdFromRoute();
    this._flatService.getFlat(this.flatUrl, this.getFlatIdFromRoute())
      .subscribe(response => {
        console.log(response);
    });
  }

  getFlatIdFromRoute() : number {
    let flatId: number;
    this._route.params.subscribe(params =>{
      flatId = params['id'];
    })
    return flatId;
  }

}