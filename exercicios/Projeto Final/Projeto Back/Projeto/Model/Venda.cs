namespace Projeto.Model
{
    public class Venda
    {
        public int ID { get; set; }
        public int ProdutoID { get; set; }
        public int quantidade { get; set; }
        public int ClientID { get; set; }
        public double valor { get; set; }
        public double preco { get; set; }
        //public virtual Produto Produto { get; set; }
        //public virtual Cliente Cliente { get; set; }
    }
}
