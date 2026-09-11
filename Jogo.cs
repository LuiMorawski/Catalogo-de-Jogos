public class Jogo
{
    public int Id {get; set;}
    public string Titulo {get; set;}
    public int AnoLancamento {get; set;}
    public DateTime DataCadastro {get; set;} = DateTime.Now;
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
}
