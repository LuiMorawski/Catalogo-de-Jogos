public class Plataforma
{
    public int Id {get; set;}
    public string Nome {get; set;}

    public List<JogoPlataforma> JogoPlataforma {get; set;} = new();

    public Plataforma (string nome)
    {
        this.Nome = nome;
    }
    
}