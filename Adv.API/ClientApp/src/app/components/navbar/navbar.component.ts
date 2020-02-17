import { Component, OnInit } from '@angular/core';
import { NzModalService, NzDrawerService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { FlatService } from 'src/app/services/flat.service';
import { Constants } from 'src/app/constants';
import { FlatModel } from 'src/app/models/flatModel';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileComponent } from 'src/app/drawers/profile/profile.component';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  isLogedIn :boolean = false;
  constructor(
    private modalService: NzModalService, 
    private flatService: FlatService,
    private router: Router, 
    public authService: AuthService,
    private drawerService: NzDrawerService,
    public navService: NavbarService
    ) { }
  ngOnInit() {
    
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
              let newFlatAdvert = new FlatModel(modalForm.value);
              /** add userId for advert */
              newFlatAdvert.userId = this.authService.currentUser.sub;
              this.flatService
                .createFlat(newFlatAdvert)
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
    const drawer = this.drawerService.create({
      nzTitle: `${user.unique_name} - Кабинет пользователя`,
      nzContent: ProfileComponent,
      nzWidth: '50%', nzClosable: true
    })
  }
}
