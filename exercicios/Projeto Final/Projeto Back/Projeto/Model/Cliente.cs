namespace Projeto.Model
{
    public class Cliente
    {
        public int ID { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public bool ativo { get; set; }
        //public virtual ICollection<Venda> Vendas { get; set; }
    }
}