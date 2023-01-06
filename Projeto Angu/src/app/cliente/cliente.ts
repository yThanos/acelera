import { Venda } from "../venda/venda";

export class Cliente{
    id?: number;
    nome?: String;
    cpf?: String;
    ativo?: boolean;

    constructor(nome?: String, cpf?: String, id?: number){
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.ativo = true;
    }
}