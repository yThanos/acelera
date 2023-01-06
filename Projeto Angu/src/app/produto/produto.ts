export class Produto{
    id?: number;
    nome?: String;
    preco?: number;
    ativo?: boolean;

    constructor(nome?: String, preco?: number, id?: number){
        this.nome = nome;
        this.preco = preco;
        this.id = id;
        this.ativo = true;
    }
}