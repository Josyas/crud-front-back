import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductTypeComponent } from './view/product-type/product-type.component';
import { CreateProducttankComponent } from './view/create-producttank/create-producttank.component';

const routes: Routes = [
  { path: '', component: CreateProducttankComponent},
  { path: 'producttype', component: ProductTypeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
