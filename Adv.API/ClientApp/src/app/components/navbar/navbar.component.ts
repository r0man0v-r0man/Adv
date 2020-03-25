import { Component, OnInit, TemplateRef } from '@angular/core';
import { NzModalService, NzDrawerService, NzNotificationService } from 'ng-zorro-antd';
import { AddAdvertComponent } from 'src/app/modal/add-advert/add-advert.component';
import { FlatService } from 'src/app/services/flat.service';
import { FlatModel } from 'src/app/models/flatModel';
import { Router, ActivatedRoute } from '@angular/router';
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
  newFlatId;
  constructor(
    private modalService: NzModalService, 
    private flatService: FlatService,
    private router: Router, 
    private route: ActivatedRoute,
    public authService: AuthService,
    private drawerService: NzDrawerService,
    public navService: NavbarService,
    private notificationService: NzNotificationService
    ) { }
  ngOnInit() {
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
              let newFlatAdvert = modalForm.value;
              /** add userId for advert */
              newFlatAdvert.userId = this.authService.currentUser.sub;
              console.log(newFlatAdvert);
              
              this.flatService
                .createFlat(newFlatAdvert)
                .subscribe(response => {
                    if(response){
                      this.notificationService.success(
                        'Объявление создано',
                        'Все хорошо, вы добавили новое объявление',
                        {
                          nzPauseOnHover: true
                        }
                      )
                      this.router.navigate(['../flats', response.id], {relativeTo: this.route.parent})
                    }
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
      nzWidth: '50%', nzClosable: false
    })
  }
}
