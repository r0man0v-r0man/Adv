import { Component, OnInit, TemplateRef } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { NzDrawerRef, NzModalService } from 'ng-zorro-antd';
import { FlatModel } from 'src/app/models/flatModel';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/UserModel';
import { FlatService } from 'src/app/services/flat.service';
import { EditAdvertComponent } from 'src/app/modal/edit-advert/edit-advert.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  loading : boolean = true;
  userFlats: FlatModel[] = [];
  userId: string;
  user: UserModel;

  constructor(
    private authService: AuthService,
    private router: Router,
    private drawerRef: NzDrawerRef,
    private userService: UserService,
    private modalService: NzModalService, 
    private flatService: FlatService
  ) { }

  ngOnInit() {
    this.userId = this.authService.currentUser.sub;
    this.getUserInfo();
  }

  logOut(){
    this.drawerRef.close();
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
  getUserInfo(){
    this.userService.getUserInfo(this.userId)
      .subscribe(response => {
        if(response){
          this.user = response;
          this.userFlats = this.user.flatsViewModels;
          this.loading = false;
        }
      })
  };
  onDelete(item: FlatModel){
    this.loading = true;
    this.flatService.delete(item.id)
      .subscribe(response => { 
        if(response) {
        let index = this.userFlats.findIndex(x=>x.id === item.id);
          
        if(index > -1) {
         this.userFlats.splice(index, 1);
        }
        this.loading = false;
      }
    });
  }
  onEdit(item: FlatModel){
    const editModal = this.modalService.create({
      nzTitle: 'Редактирование',
      nzContent: EditAdvertComponent,
      nzComponentParams: {
        flat: item
      },
      nzClosable: false,
      nzFooter:[{
        type: 'primary',
        label: 'Сохранить изменения',
        onClick: ()=>{
          editModal.destroy();
        }
      }]
    });
  }
  onMove(item: FlatModel){
    this.router.navigate(['flats/', item.id]);
    this.drawerRef.close();
  }
}
