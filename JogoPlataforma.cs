public class JogoPlataforma
{
    public int JogoId {get; set;}
    public Jogo Jogo {get; set;}
    public int PlataformaId {get; set;}
    public Plataforma Plataforma {get; set;}

    public JogoPlataforma(Jogo jogo, Plataforma plataforma)
    {
        this.Jogo = jogo;
        this.JogoId = jogo.Id;
        this.Plataforma = plataforma;
        this.PlataformaId = plataforma.Id;
    }
}