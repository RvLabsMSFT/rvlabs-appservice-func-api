import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EzauthEchoApiComponent } from './func/ezauth-echo-api/ezauth-echo-api.component';


const routes: Routes = [
  { path: 'ezauth-func', component: EzauthEchoApiComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
