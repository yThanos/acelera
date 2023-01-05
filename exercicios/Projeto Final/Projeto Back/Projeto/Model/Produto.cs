namespace Projeto.Model
{
    public class Produto
    {
        public int ID { get; set; }
        public String nome { get; set; }
        public double preco { get; set; }
        public bool ativo { get; set; }
        //public virtual ICollection<Venda> Vendas { get; set; }
    }
}