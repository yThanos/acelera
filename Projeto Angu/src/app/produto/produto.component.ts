import { Component } from '@angular/core';
import { Produto } from './produto';
import { ProdutoService } from './produto.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent {
  produto: Produto = new Produto();
  produtos: Produto[] = [];
  produtos2: Produto[] = [];
  opcao = "cad";

  constructor(private service: ProdutoService){
    this.listar();
  }

  listar(){
    this.service.getProdutos().subscribe((dados: Produto[])=>{
      this.produtos2 = dados;
      let j = 0;
      this.produtos = [];
      for(let i = 0; i< this.produtos2.length; i++){
        if(this.produtos2[i].ativo){
          this.produtos[j] = this.produtos2[i];
          j++;
        }
      }
    })
  }
  cadastrar(){
    this.service.postProduto(this.produto).subscribe(()=>{
      this.produto = new Produto();
      this.listar();
    })
  }
  editar(produto: Produto){
    this.opcao = 'edit';
    this.produto = produto;
  }
  salvar(){
    this.service.putProduto(this.produto).subscribe(()=>{
      this.produto = new Produto();
      this.listar();
      this.opcao = 'cad';
    })
  }
  deletar(produto: Produto){
    this.service.deleteProduto(produto).subscribe(()=>{
      this.listar();
    })
  }
  idpesq = 0;
  busca(){
    this.service.buscar(this.idpesq).subscribe((dado: Produto)=>{
      this.produto = dado;
      this.opcao = 'edit';
    })
  }
}