using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

public class Program
{
    static Dictionary<string, Artista> artistasRegistrados = new();
    static Dictionary<int, Menu> opcoes = new();

    public static void Main(string[] args)
    {

        Artista ira = new Artista("Ira!", "Banda Ira!");
        Artista beatles = new("The Beatles", "Banda The Beatles");

        artistasRegistrados.Add(ira.Nome, ira);
        artistasRegistrados.Add(beatles.Nome, beatles);

        opcoes.Add(1, new MenuRegistrarArtista());
        opcoes.Add(2, new MenuRegistrarMusica());
        opcoes.Add(3, new MenuMostrarArtistas());
        opcoes.Add(4, new MenuMostrarMusicas());
        opcoes.Add(0, new MenuSair());

        //new Program().ExibirOpcoesDoMenu();

        try
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();
            Console.WriteLine(connection.State);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }


    void ExibirOpcoesDoMenu()
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar um artista");
        Console.WriteLine("Digite 2 para registrar a música de um artista");
        Console.WriteLine("Digite 3 para mostrar todos os artistas");
        Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
        Console.WriteLine("Digite 0 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
        {
            Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
            menuASerExibido.Executar(artistasRegistrados);
            if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("Opção inválida");
        }
    }

    void ExibirLogo()
    {
        Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
        Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
    }

}



