
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

class Program
{
    static CatalogoServices catalogoServices = new CatalogoServices();
    public static void Main(string[] args)
    {


while(true)
        {
          // limpa o console
Console.Clear();          
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔═══════════════════════════╗");
        Console.WriteLine("║           MENU            ║");
        Console.WriteLine("╠═══════════════════════════╣");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("║ 1 - Cadastrar jogo        ║");
        Console.WriteLine("║ 2 - Listar jogos          ║");
        Console.WriteLine("║ 3 - Buscar jogo por titulo║");
        Console.WriteLine("║ 4 - Remover jogo          ║");
        Console.WriteLine("║ 5 - Avaliar jogo          ║");
        Console.WriteLine("║ 6 - Exibir ranking        ║");
        Console.WriteLine("║ 0 - Sair                  ║");
        Console.WriteLine("╚═══════════════════════════╝");

        System.Console.WriteLine("Digite o numero da opção:");
      int Op = int.Parse(System.Console.ReadLine());
        switch(Op){ 
           case 1:
           System.Console.WriteLine("Digite o titulo do Jogo: ");
           string titulo = Console.ReadLine();

           System.Console.WriteLine("Digite o ano do Jogo: ");
           int ano = int.Parse(System.Console.ReadLine());
          // Exemplo 
           Genero genero = new Genero("ACao");

           catalogoServices.CadastrarJogo(titulo,ano,genero);
           Console.ForegroundColor = ConsoleColor.Green;
           System.Console.WriteLine("Jogo Cadastrado com Sucesso!");
           Console.ForegroundColor = ConsoleColor.White;
           Console.WriteLine("\nPressione qualquer tecla para continuar...");
           Console.ReadKey();
           break;

           case 2:
           System.Console.WriteLine("Jogos Disponiveis:");
           catalogoServices.ListarJogos();
           Console.WriteLine("\nPressione qualquer tecla para continuar...");
           Console.ReadKey();
           break;

           case 3:
           System.Console.WriteLine("Digite o título (ou parte dele) que deseja buscar: ");
           string busca = Console.ReadLine();
           catalogoServices.BuscarJogo(busca);
           Console.WriteLine("\nPressione qualquer tecla para continuar...");
           Console.ReadKey();
           break;

           case 4:
           catalogoServices.ListarJogos();
           System.Console.WriteLine("Digite o id do Jogo que quer Remover: ");
           int IdJogoRemover = int.Parse(System.Console.ReadLine());
           catalogoServices.RemoverJogo(IdJogoRemover);
           Console.WriteLine("\nPressione qualquer tecla para continuar...");
           Console.ReadKey();
           break;

           case 5:
           break;

           case 6:
           break;

           case 0:
           System.Console.WriteLine("Voce Saiu!!!");
           return;

           default:
Console.ForegroundColor = ConsoleColor.Red;
System.Console.WriteLine("Opcão Invalida! Tente Novamente");
Console.ForegroundColor = ConsoleColor.White;
           break;

    } 
     }
} 
}
