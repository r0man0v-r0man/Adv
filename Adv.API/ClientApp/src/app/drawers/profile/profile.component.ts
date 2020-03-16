import { Component, OnInit, TemplateRef } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { NzDrawerRef, NzModalService } from 'ng-zorro-antd';
import { FlatModel } from 'src/app/models/flatModel';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/UserModel';
import { FlatService } from 'src/app/services/flat.service';
import { EditAdvertComponent } from 'src/app/modal/edit-advert/edit-advert.component';
import { FlatUpdateModel } from 'src/app/models/updateModels/flatUpdateModel';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  initLoading : boolean = true;
  loadingMore = false;
  userFlats: FlatModel[] = [];
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
    private flatService: FlatService
  ) { }

  ngOnInit() {
    this.pageNumber = 1;
    this.userId = this.authService.currentUser.sub;
    this.getUserInfo();
    this.getUserFlats();
  }
  onLoadMore(){
    this.loadingMore = true;
    setTimeout(() => {
    this.loadingMore = false;
      
    }, 2500);
    
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
          //this.userFlats = this.user.flatsViewModels;
          this.initLoading = false;
        }
      })
  };
  getUserFlats(){
    this.flatService.getUserFlats(this.userId, this.pageNumber)
      .subscribe(response => {
        console.log(response);
        
      })
  }
  onDelete(item: FlatModel){
    this.initLoading = true;
    this.flatService.delete(item.id)
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
        disabled: ()=> !editModal.getContentComponent().editForm.valid,
        onClick: ()=>{
          const editForm = editModal.getContentComponent().editForm;
          if(editForm.valid){
            let updatedFlat = new FlatUpdateModel(editForm.value);
            this.flatService.update(updatedFlat)
              .subscribe(response => {
                this.initLoading = true;
              console.log(response);
              editModal.destroy();
            }, ()=>{
              this.initLoading = false;
            }, ()=>{
                this.getUserInfo();
            })
          }
        }
      }]
    });
  }
  onMove(item: FlatModel){
    this.router.navigate(['flats/', item.id]);
    this.drawerRef.close();
  }
}
