import { Component, OnInit } from '@angular/core';
import { FlatService } from 'src/app/services/flat.service';
import { FlatModel } from 'src/app/models/flatModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  flats:FlatModel[]
  loading = true;
  constructor(private flatService: FlatService) { }

  ngOnInit() {
    this.initHomePage();
  }
  // setCardStyle(){
  //   this.cardStyle = {
  //     margin: 0,
  //     background: '#ECECEC',
  //     padding: '30px'
  //   }
  // }
  initHomePage(){
    this.flatService.getAll()
      .subscribe(
          flats => {
          this.flats = flats
         },
         ()=>{

         },
         ()=>{
          this.loading = false       
         }
      )
  }

}
