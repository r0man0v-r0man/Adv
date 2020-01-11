import { Component, OnInit } from '@angular/core';
import { Constants } from 'src/app/constants';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit {

  flatsUrl: string = Constants.getAllFlats;
  flats: FlatModel[] = [];
  loading = true;
  pageNumber: number;
  constructor(private flatService: FlatService) { }

  ngOnInit() {
    this.initHomePage();
  }

  onScroll(){
    if (this.pageNumber !== 1){
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
