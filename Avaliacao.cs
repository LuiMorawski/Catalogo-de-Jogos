public class Avaliacao
{
    public int Id {get; set;}
    public int JogoId {get; set;}
    public Jogo Jogo {get; set;}

    public int Nota {get; set;}
    public string Autor {get; set;}

    public DateTime DataAvalicao {get; set;} = DateTime.Now;

    public Avaliacao(Jogo jogo, int nota, string autor)
    {
        this.Jogo = jogo;
        this.JogoId = jogo.Id;
        this.Nota = nota;
        this.Autor = autor;
    }
}