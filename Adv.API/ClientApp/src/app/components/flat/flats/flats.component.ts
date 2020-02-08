import { Component, OnInit } from '@angular/core';
import { Constants } from 'src/app/constants';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';

@Component({
  selector: 'app-flats',
  templateUrl: './flats.component.html',
  styleUrls: ['./flats.component.less']
})
export class FlatsComponent implements OnInit {

  flats: FlatModel[] = [];
  list: FlatModel[] = [];
  loadingMore = false;
  initLoading = true; // bug
  pageNumber: number = 1;
  constructor(
    private flatService: FlatService,
    private navService: NavbarService,
    private footerService: FooterService

    ) { }

  ngOnInit() {
    this.navService.show();
    this.footerService.show();
    this.initHomePage();
  }

  onLoadMore(){
    this.loadingMore = true;
    this.initLoading = true;

      this.flatService.getFlats(this.pageNumber)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.flats.push(response[i]);
          }
          this.list = [...this.flats];
          this.loadingMore = false;
          this.initLoading = false;

          this.pageNumber++;
        }
        console.log(this.pageNumber);
        console.log(this.list);
      });
    
  }
  initHomePage(){
    this.flatService.getFlats(this.pageNumber)
      .subscribe(flats => {
          this.flats = flats
          this.list = flats
          this.initLoading = false;
          this.pageNumber++;

         }
      )
  }

}
