import { Component, OnInit } from '@angular/core';
import { NzModalService, NzDrawerService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { FlatService } from 'src/app/services/flat.service';
import { Constants } from 'src/app/constants';
import { FlatModel } from 'src/app/models/flatModel';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileComponent } from 'src/app/drawers/profile/profile.component';

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
    private authService: AuthService,
    private drawerService: NzDrawerService
    ) { }
  ngOnInit() {
    this.isUserLogenIn();
  }
  isUserLogenIn(){
    this.isLogedIn = this.authService.isLogedIn();
  }

  goToDetails(id: number){
    this.router.navigate(['flats', id]);
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
  /**
   * open profile drawer
   */
  openProfileDrawer(){
    const user = this.authService.currentUser;
    console.log(user);
    const drawer = this.drawerService.create({
      nzTitle: user.unique_name,
      nzContent: ProfileComponent,
      nzWidth: 640
    })
  }
}
