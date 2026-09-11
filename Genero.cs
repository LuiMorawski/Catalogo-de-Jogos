public class Genero
{
    
    public int Id {get; set;}
    public string Nome {get; set;}
    public List<Jogo> Jogos {get; set;} = new(); 

    public Genero (string nome)
    {
        this.Nome = nome;
    }
}