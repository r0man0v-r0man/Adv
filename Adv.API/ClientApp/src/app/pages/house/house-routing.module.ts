import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HouseSaleComponent } from './house-sale/house-sale.component';
import { HouseRentComponent } from './house-rent/house-rent.component';


const routes: Routes = [
  {
    path: '',
    children:[
      {
        path: 'sale/:id', 
        component: HouseSaleComponent
      },
      { 
        path: 'rent/:id', 
        component: HouseRentComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HouseRoutingModule { }
