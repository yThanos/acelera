import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VendaComponent } from './venda.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    VendaComponent
  ],
  exports: [
    VendaComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ]
})
export class VendaModule { }