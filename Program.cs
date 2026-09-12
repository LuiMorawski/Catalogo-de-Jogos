
class Program
{
    
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
