import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlatSaleComponent } from './flat-sale/flat-sale.component';
import { FlatRentComponent } from './flat-rent/flat-rent.component';


const routes: Routes = [
  {
    path: '',
    children:[
      {
        path: 'sale/:id', 
        component: FlatSaleComponent
      },
      { 
        path: 'rent/:id', 
        component: FlatRentComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FlatRoutingModule { }
