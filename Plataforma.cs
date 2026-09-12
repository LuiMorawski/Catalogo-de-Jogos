public class Plataforma
{
    public int Id {get; set;}
    public string Nome {get; set;}

    //Aqui a lista tem que ser de JogoPlataforma, pois se colocar Jogo direto a relação fica de 1 -> N e precisamos da relação de N -> N
    public List<JogoPlataforma> JogoPlataformas {get; set;} = new();

    public Plataforma (string nome)
    {
        this.Nome = nome;
    }

    //Mesma lógica do gênero, porém com JogoPlataforma
    public bool PodeSerExcluido()
    {
        return JogoPlataformas.Count == 0;
    } 

    
}