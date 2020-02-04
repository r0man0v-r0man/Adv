import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { NzDrawerRef } from 'ng-zorro-antd';
import { FlatModel } from 'src/app/models/flatModel';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/UserModel';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  userFlats: FlatModel[] = [];
  userId: string;
  user: UserModel;
  constructor(
    private authService: AuthService,
    private router: Router,
    private drawerRef: NzDrawerRef,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.userId = this.authService.currentUser.sub;
    this.getUserInfo();
    console.log(this.user)
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
        }
      })
  };
  onDelete(item: FlatModel){
    console.log(item.id);
  }
}
