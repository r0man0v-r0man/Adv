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
  constructor(
    private modalService: NzModalService, 
    private flatService: FlatService,
    private router: Router, 
    public authService: AuthService) { }
  ngOnInit() {
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
}
