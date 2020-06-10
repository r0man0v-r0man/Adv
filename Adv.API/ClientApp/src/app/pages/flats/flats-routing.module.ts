import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleComponent } from './sale/sale.component';
import { RentComponent } from './rent/rent.component';


const routes: Routes = [
  {
    path: '',
    children:[
      {
        path: 'sale', 
        component: SaleComponent
      },
      { 
        path: 'rent', 
        component: RentComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FlatsRoutingModule { }
