import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { FlatService } from 'src/app/services/flat.service';
import { Constants } from 'src/app/constants';
import { FlatModel } from 'src/app/models/flatModel';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  createFlatUrl: string = Constants.flat;
  isLogedIn :boolean = false;
  constructor(
    private modalService: NzModalService, 
    private flatService: FlatService,
    private router: Router, 
    private authService: AuthService) { }
  ngOnInit() {
    this.isUserLogenIn();
  }
  isUserLogenIn(){
    this.isLogedIn = this.authService.isLogedIn();
  }
  logOut(){
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
  goToDetails(id: number){
    this.router.navigate(['flat', id]);
  }
  showAddAdvertModal(){
  const modal = this.modalService.create({
      nzTitle: 'Добавить объявление',
      nzContent: AddAdvertComponent,
      nzFooter:[
        {
          type: 'primary',
          label: 'Добавить',
          disabled: ()=> !modal.getContentComponent().form.valid,
          onClick: ()=>{
            const modalForm = modal.getContentComponent().form;
            if(modalForm.valid){
              let newFlatAdvert = new FlatModel(modalForm.value)
              this.flatService
                .createFlat( 
                  this.createFlatUrl, 
                  newFlatAdvert)
                .subscribe(
                  response => {
                    this.goToDetails(response.id);
                  }
                );
              modal.destroy();
            }
          }
        }
      ]
    });
  }
  /**
   * redirect to login page if user is not logedIn
   */
  registerThenAddAdvert(){
    this.router.navigate(['/login']);
  }
}
