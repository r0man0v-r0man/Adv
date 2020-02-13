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

  list: FlatModel[] = [];
  initLoading = false; // bug
  /**Show or hide loadMore button */
  isShowMoreButton: boolean = false;
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
    this.initLoading = true;

      this.flatService.getFlats(this.pageNumber)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.list.push(response[i]);
          }
          this.pageNumber++;
        this.initLoading = false;

        }
        if(response && response.length === 0){
          this.isShowMoreButton = false;
        }
        this.initLoading = false;



        console.log(this.pageNumber);
        console.log(this.list);
      });
    
  }
  initHomePage(){
    this.initLoading = true;
    this.flatService.getFlats(this.pageNumber)
      .subscribe(flats => {
        if(flats && flats.length !== 0){
          this.list = flats
          this.initLoading = false;
          this.pageNumber++;
        }},()=>{}, ()=>
        {
          this.isShowMoreButton = true;
        })
  }

}
