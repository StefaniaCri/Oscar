import { importType } from '@angular/compiler/src/output/output_ast';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './component/login/login.component';

import { ProductComponent } from './product/product.component';

const routes: Routes = [
{path:'product',component:ProductComponent},
{path:'login',component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
