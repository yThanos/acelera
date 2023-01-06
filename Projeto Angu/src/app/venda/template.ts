export class Template{
    id?: number;
    nomecli?: String;
    nomepro?: String;
    valor?: number;
    constructor(id?: number, nomecli?: String, nomepro?: String, valor?: number){
        this.id = id;
        this.nomecli = nomecli;
        this.nomepro = nomepro;
        this.valor = valor;
    }
}