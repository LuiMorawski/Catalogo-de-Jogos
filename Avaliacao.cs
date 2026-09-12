public class Avaliacao
{
    public int Id {get; set;}
    public int JogoId {get; set;}
    public Jogo Jogo {get; set;}

    public int Nota {get; set;}
    public string Autor {get; set;}

    public DateTime DataAvaliacao {get; set;} = DateTime.Now;

    public Avaliacao(Jogo jogo, int nota, string autor)
    {
        //Lançamento de exceção que precisa de um try/catch no menu
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentException("A nota deve estar entre 0 e 10");
        }

        this.Jogo = jogo;
        this.JogoId = jogo.Id;
        this.Nota = nota;
        this.Autor = autor;
    }


}