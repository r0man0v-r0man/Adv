import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { AdvertService } from 'src/app/services/advert.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit {
  userId;
  constructor(
    private router: Router,
    private authService: AuthService,
    private advertService: AdvertService
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.currentUser.sub;
    this.advertService.getUserAdverts(this.userId).subscribe(data => {
      console.log(data);
    })
  }

  logOut(){
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
}
