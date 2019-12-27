import { Component, OnInit } from '@angular/core';
import { FlatService } from 'src/app/services/flat.service';
import { FlatModel } from 'src/app/models/flatModel';
import { Constants } from 'src/app/constants';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  flatsUrl: string = Constants.getAllFlats;
  flats:FlatModel[] = [];
  loading = true;
  pageNumber: number = 1;
  constructor(private flatService: FlatService) { }

  ngOnInit() {
    this.initHomePage();
  }
  onScroll(){
    this.flatService.getFlats(this.flatsUrl, this.pageNumber)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.flats.push(response[i]);
          }
        }
      },
      ()=>{}
      ,
      ()=>{
        this.pageNumber++;
      })
  }
  initHomePage(){
    this.flatService.getFlats(this.flatsUrl, this.pageNumber)
      .subscribe(
          flats => {
          this.flats = flats
         },
         ()=>{

         },
         ()=>{
          this.loading = false;
          this.pageNumber++;
         }
      )
  }

}
