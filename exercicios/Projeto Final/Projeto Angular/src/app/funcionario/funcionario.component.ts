import { Component } from '@angular/core';
import { Funcionario } from './funcionario';
import { FuncionarioService } from './funcionario.service';

@Component({
  selector: 'app-funcionario',
  templateUrl: './funcionario.component.html',
  styleUrls: ['./funcionario.component.css']
})
export class FuncionarioComponent {

  constructor(private service: FuncionarioService){
    this.listar();
  }

  funcionario: Funcionario = new Funcionario();
  funcionarios: Funcionario[] = [];
  funcionarios2: Funcionario[] = [];
  opcao = 'cad';
  adm = 'Admin';
  est = 'Estoque';
  ven = 'Vendas';
  rh = 'RH';

  listar(){
    this.service.getFuncionarios().subscribe((dados: Funcionario[])=> {
      this.funcionarios2 = dados;
      let j = 0;
      this.funcionarios = [];
      for(let i = 0; i< this.funcionarios2.length; i++){
        if(this.funcionarios2[i].ativo){
          this.funcionarios[j] = this.funcionarios2[i];
          j++;
        }
      }
    })
  }
  buscar(id: number){
    this.service.getFuncionario(id).subscribe((dados: Funcionario)=>{
      this.funcionario = dados;
    })
  }
  cadastrar(){
    this.funcionario.id = this.funcionarios2.length;
    this.funcionario.username = this.funcionario.username;
    this.funcionario.senha = this.funcionario.senha;
    this.funcionario.permissao = this.funcionario.permissao;
    this.funcionario.nome = this.funcionario.nome
    this.funcionario.telefone = this.funcionario.telefone
    this.funcionario.email = this.funcionario.email
    this.funcionario.ativo = true;
    this.service.postFuncionario(this.funcionario).subscribe(()=>{
      this.funcionario = new Funcionario();
      this.listar();
    })
  }
  editar(funcionario: Funcionario){
    this.funcionario = funcionario;
    this.opcao = 'edit';
  }
  salvar(){
    this.service.putFuncionario(this.funcionario).subscribe(()=>{
      this.funcionario = new Funcionario();
      this.listar();
      this.opcao = 'cad'
    })
  }
  deletar(funcionario: Funcionario){
    this.service.deleteFuncionario(funcionario).subscribe(()=>{
      this.listar();
      funcionario = new Funcionario();
    })
  }
  idpesq = 0;
  busca(){
    this.service.buscar(this.idpesq).subscribe((dado:Funcionario)=>{
      this.funcionario = dado;
      this.opcao = 'edit'
    })
  }
}