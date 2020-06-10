import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlatsComponent } from './flats.component';


const routes: Routes = [
  {
    path: '',
    component: FlatsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FlatsRoutingModule { }
