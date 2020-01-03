import { Component, OnInit, OnDestroy } from '@angular/core';
import { FlatService } from 'src/app/services/flat.service';
import { FlatModel } from 'src/app/models/flatModel';
import { Constants } from 'src/app/constants';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit, OnDestroy {

  flatsUrl: string = Constants.getAllFlats;
  flats:FlatModel[] = [];
  loading = true;
  pageNumber: number;
  constructor(private flatService: FlatService) { }

  ngOnInit() {
    this.initHomePage();
  }
  ngOnDestroy(): void {
    this.flats = [];
  }
  onScroll(){
    if (this.flats.length !== 0){
      this.flatService.getFlats(this.flatsUrl, this.pageNumber)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.flats.push(response[i]);
          }
        }
      },
      ()=>{},
      ()=>{
        this.pageNumber++;
      });
    }
  }
  initHomePage(){
    this.pageNumber = 1;
    this.flatService.getFlats(this.flatsUrl, this.pageNumber)
      .subscribe(flats => {
          this.flats = flats
          this.loading = false;
         },
         ()=>{},
         ()=>{
           this.pageNumber++;
         }
      )
  }

}
