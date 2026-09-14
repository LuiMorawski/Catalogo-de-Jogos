
public class CatalogoServices
{
    // Lista dos jogos
public List <Jogo> jogos = new();
// id do jogo
private int proximoId = 1;

public List<Genero> generos = new();
private int proximoIdGenero = 1;




public void CadastrarJogo(String titulo, int ano, Genero genero)
    {
        Jogo jogo = new Jogo(titulo, ano,genero);
        jogo.Id = proximoId;
        proximoId++;
        jogos.Add(jogo);
        
        genero.Jogos.Add(jogo);
    }

public Genero ObterOuCriarGenero(string nome)
    {
        foreach (var g in generos)
        {
            if(g.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return g;
            }
        }
        Genero novo = new Genero(nome);
        novo.Id = proximoIdGenero;
        proximoIdGenero++;
        generos.Add(novo);
        return novo;
    }

public void ListarJogos()
    {
        foreach (var jogo in jogos)
        {
            Console.WriteLine($"ID: {jogo.Id} | Nome: {jogo.Titulo} - Ano: {jogo.AnoLancamento} - Genero: {jogo.Genero.Nome}");
        }
    }
    public void BuscarJogo(string busca)
    {
        foreach (var jogo in jogos)
        {
            // aqui é igual o equals porem ele busca por ser parecido e não exatamente igual o nome do jogo
            if(jogo.Titulo.Contains(busca, StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine(jogo.Titulo + " - " + jogo.AnoLancamento + " - " + jogo.Genero.Nome);
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
    }
        // procura o jogo pelo id devolve null se nao encontrar 
        public Jogo BuscarJogoPorId(int id)
        {
            foreach (var jogo in jogos)
            {
                if (jogo.Id == id)
                {
                    return jogo;
                }
            }
            return null; 
        }
         
    // o Jogo.AdicionarAvaliacao ja checa se o autor repetiu
    public void AvaliarJogo(int idJogo, string autor, int nota, string comentario)
    {
        Jogo jogo = BuscarJogoPorId(idJogo);
 
        if (jogo == null)
        {
            throw new ArgumentException("Jogo nao encontrado.");
        }
 
        Avaliacao avaliacao = new Avaliacao(jogo, nota, autor);
        avaliacao.Comentario = comentario;
 
        jogo.AdicionarAvaliacao(avaliacao);
    }
 
    // mostra os jogos ordenados da maior media pra menor
    public void ExibirRanking()
    {
        List<Jogo> ranking = jogos.OrderByDescending(j => j.CalcularMediaAvaliacoes()).ToList();
 
        int posicao = 1;
        foreach (var jogo in ranking)
        {
            Console.WriteLine($"{posicao}º - {jogo.Titulo} | Media: {jogo.CalcularMediaAvaliacoes():F1}/10");
            posicao++;
    }

}

}