import { Component } from '@angular/core';
import { Cliente } from '../cliente/cliente';
import { Produto } from '../produto/produto';
import { Template } from './template';
import { Venda } from './venda';
import { VendaService } from './venda.service';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent {
  venda: Venda = new Venda();
  produtos: Produto[] = [];
  clientes: Cliente[] = [];
  produtos2: Produto[] = [];
  clientes2: Cliente[] = [];
  cliente: Cliente = new Cliente();
  produto: Produto = new Produto();
  quantidade?: number;
  cli?: String;
  pro?: String;

  constructor(private service: VendaService){
    this.listaProd();
    this.listaCli();
    this.listar();
  }

  listaProd(){
    this.service.getProdutos().subscribe((dados: Produto[])=>{
      this.produtos2 = dados;
      let j = 0;
      for(let i = 0; i< this.produtos2.length; i++){
        if(this.produtos2[i].ativo){
          this.produtos[j] = this.produtos2[i];
          j++;
        }
      }
    })
  }
  listaCli(){
    this.service.getClientes().subscribe((dados: Cliente[])=>{
      this.clientes2 = dados;
      let j = 0;
      for(let i = 0; i< this.clientes2.length; i++){
        if(this.clientes2[i].ativo){
          this.clientes[j] = this.clientes2[i];
          j++;
        }
      }
    })
  }
  cadastrar(){
    this.venda.id = 0;
    this.venda.produtoID = this.produto.id;
    this.venda.quantidade = this.quantidade;
    this.venda.clientID = this.cliente.id;
    this.venda.preco = this.produto.preco;
    this.venda.valor = 0;
    this.service.postVendas(this.venda).subscribe(()=>{
      this.venda = new Venda();
      this.listar();
    })
  }
  listar(){
    this.service.getVendas().subscribe((dados: Venda[])=>{
      this.vend = dados;
      this.carregar();
    })
  }
  carregar(){
    for(let i = 0; i < this.vend.length; i++){
      this.service.getPro(this.vend[i].produtoID).subscribe((produto: Produto)=>{
        this.pro = produto.nome
        console.log(this.pro)
      })
      for(let i = 0; i<100000000; i++){}
      this.service.getCli(this.vend[i].clientID).subscribe((cliente: Cliente)=>{
        this.cli = cliente.nome
        console.log(this.cli)
        this.temp = new Template(this.vend[i].id, this.cli, this.pro, this.vend[i].valor);
        this.vendas[i] = this.temp;
      })
    }
  }
  vend: Venda[] = [];
  vendas: Template[] = [];
  temp?: Template;
}
