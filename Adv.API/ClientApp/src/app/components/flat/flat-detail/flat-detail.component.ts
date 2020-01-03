import { Component, OnInit } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Constants } from 'src/app/constants';

@Component({
  selector: 'app-flat-detail',
  templateUrl: './flat-detail.component.html',
  styleUrls: ['./flat-detail.component.less']
})

export class FlatDetailComponent implements OnInit {
  flatUrl:string = Constants.flat;
  flat: FlatModel = new FlatModel();

  constructor(
    private flatService:FlatService,
    private route: ActivatedRoute,
    private router: Router
  ) {  }

  ngOnInit() {
    this.routeReUseStrategy();
    this.getFlat(this.getFlatIdFromRoute());
  }

  getFlat(id: number){
    this.flatService.getFlat(this.flatUrl, id)
    .subscribe(
      response => {
      this.flat = response
  });
  }

  routeReUseStrategy(){
    // override the route reuse strategy
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
    this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
        // trick the Router into believing it's last link wasn't previously loaded
        this.router.navigated = false;
      }
    });
  }


  getFlatIdFromRoute() : number {
    let flatId: number;
    this.route.params.subscribe(params =>{
      flatId = params['id'];
    })
    return flatId;
  }

}