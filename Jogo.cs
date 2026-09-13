public class Jogo
{
    public int Id {get; set;}
    public string Titulo {get; set;}
    public int AnoLancamento {get; set;}
    public DateTime DataCadastro {get; set;} = DateTime.Now;

    //Aqui a relação é de N -> 1, pois os jogos criados podem ter apenas 1 gênero 
    public int GeneroId {get; set;}
    public Genero Genero {get; set;}
    
    public List<JogoPlataforma> JogoPlataformas {get; set;} = new();
    public List <Avaliacao> Avaliacoes {get; set;} = new();

    public Jogo (string titulo, int anoLancamento, Genero genero)
    {
        this.Titulo = titulo;
        this.AnoLancamento = anoLancamento;
        this.Genero = genero;
        this.GeneroId = genero.Id;
    }

    //Recebe uma plataforma como parâmetro, que é a vamos vincular a esse jogo que vai ser criada
    public void AdicionarPlataforma(Plataforma plataforma)
    {
        //Any -> Método do LINQ(para manipulação de listas) que devolve true se pelo menos um item da lista satisfazer a condição
        bool jaExiste = JogoPlataformas.Any(jp => jp.PlataformaId == plataforma.Id);// Expressão lambda

        if (jaExiste)
        {
            Console.WriteLine("Essa plataforma já está vinculada a esse jogo.");
            return;
        }

        JogoPlataformas.Add(new JogoPlataforma(this, plataforma)); // -> this significa "o jogo atual, esse objeto aqui que está executando esse método".
    }

    public void AdicionarAvaliacao(Avaliacao avaliacao)
    {
        bool autorJaAvaliou = Avaliacoes.Any(a => a.Autor == avaliacao.Autor);

        if (autorJaAvaliou)
        {
            Console.WriteLine("Esse autor já avaliou esse jogo.");
            return;
        }

        Avaliacoes.Add(avaliacao);
    }

    public double CalcularMediaAvaliacoes()
    {
        if (Avaliacoes.Count == 0)
        {
            return 0;
        }

        return Avaliacoes.Average(a => a.Nota); //.Average(...) → método do LINQ que calcula a média automaticamente de uma lista de números.
    }

    
}
