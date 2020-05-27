import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoreapiComponent } from './coreapi/coreapi.component';


const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
