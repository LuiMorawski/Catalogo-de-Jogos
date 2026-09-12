public class Genero
{
    
    public int Id {get; set;}
    public string Nome {get; set;}
    public List<Jogo> Jogos {get; set;} = new(); 

    //Esse construtor vazio serve para quando for instanciado um gênero novo não precisar passar nenhum nome como parâmetro (Em C# pode ter dois construtores)
    public Genero (){}

    //Esse aqui pode instaciar passando o parâmetro do nome (quando instanciado, um ignora o outro)
    public Genero (string nome)
    {
        this.Nome = nome;
    }

    //Método que diz que se um existir um jogo do gênero em questão, o gênero não pode ser excluído 
    public bool PodeSerExcluido()
    {
        return Jogos.Count == 0;
    }
}