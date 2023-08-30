using System;
using System.Collections.Generic;

public class Produto
{
    public string Nome { get; set; } = "";
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public string Categoria { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Fabricante { get; set; } = "";

    public Produto(string nome, decimal preco, string categoria, string descricao, string fabricante)
    {
        Nome = nome;
        Preco = preco;
        QuantidadeEmEstoque = 0;
        Categoria = categoria;
        Descricao = descricao;
        Fabricante = fabricante;
    }
}

class Program
{
    static List<Produto> estoque = new List<Produto>();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            MostrarMenu();
            opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    AdicionarProduto();
                    break;
                case 2:
                    ListarProdutos();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    EntradaEstoque();
                    break;
                case 5:
                    SaidaEstoque();
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("[1] Novo [4] Entrada Estoque");
        Console.WriteLine("[2] Listar Produtos [5] Saída Estoque");
        Console.WriteLine("[3] Remover Produtos [0] Sair");
    }

    static int LerOpcao()
    {
        Console.Write("Escolha uma opção: ");
        int opcao;
        while (!int.TryParse(Console.ReadLine(), out opcao))
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.Write("Escolha uma opção: ");
        }
        return opcao;
    }


    static void AdicionarProduto()
    {
        Console.WriteLine("Digite os detalhes do novo produto:");
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Preço: ");
        decimal preco;
        while (!decimal.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.InvariantCulture, out preco))
        {
            Console.WriteLine("Preço inválido. Tente novamente.");
            Console.Write("Preço: ");
        }

        Console.Write("Categoria: ");
        string categoria = Console.ReadLine() ?? "";
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? "";
        Console.Write("Fabricante: ");
        string fabricante = Console.ReadLine() ?? "";

        Produto novoProduto = new Produto(nome, preco, categoria, descricao, fabricante);
        estoque.Add(novoProduto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos()
    {
        if (estoque.Count == 0)
        {
            Console.WriteLine("Nenhum produto no estoque.");
        }
        else
        {
            Console.WriteLine("Produtos em estoque:");
            foreach (var produto in estoque)
            {
                Console.WriteLine($"Nome: {produto.Nome}, Preço: {produto.Preco:C}, Quantidade: {produto.QuantidadeEmEstoque}");
            }
        }
    }

    static void RemoverProduto()
    {
        Console.Write("Digite o nome do produto a ser removido: ");
        string nome = Console.ReadLine();

        Produto produtoRemover = estoque.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (produtoRemover != null)
        {
            estoque.Remove(produtoRemover);
            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque.");
        }
    }

    static void EntradaEstoque()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Produto produto = estoque.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (produto != null)
        {
            Console.Write("Digite a quantidade de entrada: ");
            int quantidade = int.Parse(Console.ReadLine());
            produto.QuantidadeEmEstoque += quantidade;
            Console.WriteLine($"Entrada de {quantidade} unidades no estoque.");
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque.");
        }
    }

    static void SaidaEstoque()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Produto produto = estoque.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (produto != null)
        {
            Console.Write("Digite a quantidade de saída: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade <= produto.QuantidadeEmEstoque)
            {
                produto.QuantidadeEmEstoque -= quantidade;
                Console.WriteLine($"Saída de {quantidade} unidades do estoque.");
            }
            else
            {
                Console.WriteLine("Quantidade indisponível em estoque.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque.");
        }
    }
}
