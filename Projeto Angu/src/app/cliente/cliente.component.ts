import { Component } from '@angular/core';
import { Cliente } from './cliente';
import { ClienteService } from './cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent {
  cliente: Cliente = new Cliente();
  clientes: Cliente[] = [];
  clientes2: Cliente[] = [];
  opcao = "cad";

  constructor(private service: ClienteService){
    this.listar();
  }

  listar(){
    this.service.getClientes().subscribe((dados: Cliente[])=>{
      this.clientes2 = dados;
      let j = 0;
      this.clientes = [];
      for(let i = 0; i< this.clientes2.length; i++){
        if(this.clientes2[i].ativo){
          this.clientes[j] = this.clientes2[i];
          j++;
        }
      }
    })
  }
  cadastrar(){
    this.service.postCliente(this.cliente).subscribe(()=>{
      this.cliente = new Cliente();
      this.listar();
    })
  }
  editar(cliente: Cliente){
    this.opcao = 'edit';
    this.cliente = cliente;
  }
  salvar(){
    this.service.putCliente(this.cliente).subscribe(()=>{
      this.cliente = new Cliente();
      this.listar();
      this.opcao = 'cad';
    })
  }
    deletar(cliente: Cliente){
    this.service.deleteCliente(cliente).subscribe(()=>{
      this.listar();
    })
  }
  idpesq = 0;
  busca(){
    this.service.buscar(this.idpesq).subscribe((dado: Cliente)=>{
      this.cliente = dado;
      this.opcao = 'edit'
    })
  }
}