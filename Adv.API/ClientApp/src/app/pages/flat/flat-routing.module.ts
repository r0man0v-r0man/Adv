import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlatComponent } from './flat.component';


const routes: Routes = [
  { path: ':id', component: FlatComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FlatRoutingModule { }
