import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProdutoComponent } from './produto/produto.component';
import { VendaComponent } from './venda/venda.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'funcionarios', component: FuncionarioComponent, canActivate: [AuthGuard]},
  {path: 'clientes', component: ClienteComponent, canActivate: [AuthGuard]},
  {path: 'produtos', component: ProdutoComponent, canActivate: [AuthGuard]},
  {path: 'vendas', component: VendaComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
