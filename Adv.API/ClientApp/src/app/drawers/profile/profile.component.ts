import { Component, OnInit, TemplateRef } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { NzDrawerRef, NzModalService } from 'ng-zorro-antd';
import { FlatRentModel } from 'src/app/models/flatRentModel';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/UserModel';
import { EditAdvertComponent } from 'src/app/modal/edit-advert/edit-advert.component';
import { FlatUpdateModel } from 'src/app/models/updateModels/flatUpdateModel';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  initLoading : boolean = true;
  loadingMore = false;
  userFlats: FlatRentModel[] = [];
  userId: string;
  user: UserModel;
  /**pageNumber for Profiles flats */
  pageNumber: number;
  constructor(
    private authService: AuthService,
    private router: Router,
    private drawerRef: NzDrawerRef,
    private userService: UserService,
    private modalService: NzModalService, 
    private advertService: AdvertService
  ) { }

  ngOnInit() {
    this.pageNumber = 1;
    this.userId = this.authService.currentUser.sub;
    this.getUserInfo();
    this.getUserFlats();
  }
  onLoadMore(){
    this.initLoading = true;
    this.loadingMore = true;
    this.advertService.getUserFlats(this.userId, this.pageNumber)
      .subscribe(response => {
        if(response && response.length > 0){
          for(var i = 0; i < response.length; i++){
            this.userFlats.push(response[i]);
            this.loadingMore = false;
            this.initLoading = false;
          }
          this.pageNumber++;
        }else{
          this.initLoading = false;
        }
      })
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
        }
      })
  };
  getUserFlats(){
    this.advertService.getUserFlats(this.userId, this.pageNumber)
      .subscribe(response => {
        this.userFlats = response;
        this.initLoading = false;
        this.pageNumber++;
      })
  }
  onDelete(item: FlatRentModel){
    this.initLoading = true;
    this.advertService.delete(item.id)
      .subscribe(response => { 
        if(response) {
        let index = this.userFlats.findIndex(x=>x.id === item.id);
          
        if(index > -1) {
         this.userFlats.splice(index, 1);
        }
        this.initLoading = false;
      }
    });
  }
  onEdit(item: FlatRentModel){
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
        disabled: () => 
          !editModal.getContentComponent().editForm.valid,
        onClick: () => {
          const editForm = editModal.getContentComponent().editForm;
          if(editForm.valid){
            let updatedFlat = {
              ...editForm.value
            }
            // todo переделать, т.к. у нас теперь не только квартиры
            this.advertService.update(updatedFlat)
              .subscribe(response => {
                this.initLoading = true;
              console.log(response);
              editModal.destroy();
            }, ()=>{
              this.initLoading = false;
            }, ()=>{
              this.initLoading = false;
            })
          }
        }
      }]
    });
  }
  onMove(item: FlatRentModel){    
    this.router.navigate(['flats/', item.id]);
    this.drawerRef.close();
  }
}
