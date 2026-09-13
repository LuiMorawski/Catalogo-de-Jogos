using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

public class CatalogoServices
{
    // Lista dos jogos
public List <Jogo> jogos = new();
// id do jogo
private int proximoId = 1;

public void CadastrarJogo(String titulo, int ano, Genero genero)
    {
        Jogo jogo = new Jogo(titulo, ano,genero);
        jogo.Id = proximoId;
        proximoId++;
        jogos.Add(jogo);

    }

public void ListarJogos()
    {
        foreach (var jogo in jogos)
        {
            Console.WriteLine($"ID: {jogo.Id} | Nome: {jogo.Titulo} - Ano: {jogo.AnoLancamento} ");
        }
    }
    public void BuscarJogo(string busca)
    {
        foreach (var jogo in jogos)
        {
            // aqui é igual o equals porem ele busca por ser parecido e não exatamente igual o nome do jogo
            if(jogo.Titulo.Contains(busca, StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine(jogo.Titulo + " - " + jogo.AnoLancamento);
            }
        }
    }
    public void RemoverJogo(int IdJogoRemover)
    {
        // O ? serve avisar o C# que nesse caso específico, o jogo permitido ser nulo
        Jogo? Jogoencontrado = null;
foreach (var jogo in jogos)
        {
            if(jogo.Id == IdJogoRemover)
            {
                Jogoencontrado = jogo;
            }
        }
        if(Jogoencontrado != null)
        {
            jogos.Remove(Jogoencontrado);
            System.Console.WriteLine("Jogo removido com Sucesso!!");
        }
        else
        {
        Console.ForegroundColor = ConsoleColor.Red; 
            System.Console.WriteLine("Jogo não Encontrado");
            Console.ForegroundColor = ConsoleColor.White;
        }
{
    
}
    }

}