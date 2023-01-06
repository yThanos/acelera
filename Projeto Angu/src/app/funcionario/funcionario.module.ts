import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { FuncionarioComponent } from './funcionario.component';



@NgModule({
  declarations: [
    FuncionarioComponent
  ],
  exports: [
    FuncionarioComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule  
  ]
})
export class FuncionarioModule { }
