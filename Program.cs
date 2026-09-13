
class Program
{
    static CatalogoServico catalogo = new CatalogoServico();
    public static void Main(string[] args)
    {

while(true)
        {
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
           break;

           case 2:
           break;

           case 3:
           break;

           case 4:
           break;

           case 5:
           AvaliarJogoMenu();
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

static void AvaliarJogoMenu()
    {
        try
        {
            Console.WriteLine("Digite o ID do jogo que deseja avaliar:");
            if (!int.TryParse(Console.ReadLine(), out int idJogo))
            {
                MostrarErro("Id invalido.");
                return;
            }
 
            Console.WriteLine("Digite seu nome:");
            string autor = Console.ReadLine();
 
            Console.WriteLine("Digite sua nota (0 a 10):");
            if (!int.TryParse(Console.ReadLine(), out int nota))
            {
                MostrarErro("Nota invalida.");
                return;
            }
 
            Console.WriteLine("Digite seu comentario (opcional):");
            string comentario = Console.ReadLine();
 
            var avaliacao = catalogo.AvaliarJogo(idJogo, autor, nota, comentario);
 
            MostrarSucesso($"Avaliação registrada para \"{avaliacao.Jogo.Titulo}\"!");
        }
        catch (Exception ex)
        {
            MostrarErro(ex.Message);
        }
    }
  static void MostrarErro(string mensagem)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(mensagem);
    Console.ForegroundColor = ConsoleColor.White;
  }
  static void MostrarSucesso(string mensagem)
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(mensagem);
    Console.ForegroundColor = ConsoleColor.White;
  }
}
