export class Funcionario {
    id?: number;
    username?: String;
    senha?: String;
    permissao?: String;
    nome?: String;
    telefone?: String
    email?: String;
    ativo?: boolean;

    constructor(id?: number, cpf?: String, senha?: String, permissao?: String, nome?: String, telefone?: String, email?: String, ativo?: boolean){
        this.id = id;
        this.username = cpf;
        this.senha = senha;
        this.permissao = permissao;
        this.nome = nome;
        this.telefone = telefone;
        this.email = email;
        this.ativo = ativo;
    }
}