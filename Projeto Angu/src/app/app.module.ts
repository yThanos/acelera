import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';  
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FuncionarioModule } from './funcionario/funcionario.module';
import { ClienteModule } from './cliente/cliente.module';
import { ProdutoModule } from './produto/produto.module';
import { VendaModule } from './venda/venda.module';
import { LoginModule } from './login/login.module';
import { JwtModule } from '@auth0/angular-jwt';
import { HomeComponent } from './home/home.component';

export function tokenGetter() { 
  return localStorage.getItem("jwt"); 
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter : tokenGetter,
        allowedDomains: ["localhost:7087"],
        disallowedRoutes: []
      }
    }),
    BrowserModule,
    AppRoutingModule,
    FuncionarioModule,
    ClienteModule,
    ProdutoModule,
    VendaModule,
    LoginModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
