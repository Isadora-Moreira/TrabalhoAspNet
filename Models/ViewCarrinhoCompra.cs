using TrabalhoASPNet.Models;

namespace TrabalhoAspNet.Models;

public class ViewCarrinhoCompra
{
    public Compra Compra { get; set; }
    public List<Carrinho> CarrinhoItens { get; set; }
}