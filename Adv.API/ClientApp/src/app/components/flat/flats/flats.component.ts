import { Component, OnInit } from '@angular/core';
import { FlatModel } from 'src/app/models/flatModel';
import { FlatService } from 'src/app/services/flat.service';
import { NavbarService } from 'src/app/services/navbar.service';
import { FooterService } from 'src/app/services/footer.service';
import { Router } from '@angular/router';

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
    private footerService: FooterService,
    private router: Router,
    ) { }

  ngOnInit() {
    this.navService.show();
    this.footerService.show();
    this.initHomePage();
  }
  onCardClick(flat: FlatModel){
    this.router.navigate(['flats/', flat.id]);
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
          this.isShowMoreButton = true;
        } else {
          this.initLoading = false;
          this.isShowMoreButton = false;
        }
      })
  }

}
