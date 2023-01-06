import { Cliente } from "../cliente/cliente";
import { Produto } from "../produto/produto";

export class Venda{
    id?: number;
    produtoID?: number;
    quantidade?: number;
    clientID?: number;
    valor?: number;
    preco?: number;

    constructor(id?: number, cliente?: Cliente, produto?: Produto, quantidade?: number){
        this.id = id;
        this.clientID = cliente?.id;
        this.produtoID = produto?.id;
        this.quantidade = quantidade;
        this.preco = produto?.preco;
    }
}