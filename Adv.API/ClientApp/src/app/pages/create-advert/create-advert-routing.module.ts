import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateAdvertComponent } from './create-advert.component';


const routes: Routes = [
  { path: '',  component: CreateAdvertComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateAdvertRoutingModule { }
