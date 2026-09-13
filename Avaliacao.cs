using System;
public class Avaliacao
{
    public int Id {get; set;}
    public int JogoId {get; set;}
    public Jogo Jogo {get; set;}

    public int Nota {get; set;}
    public string Autor {get; set;}
    public string Comentario {get; set;}

    public DateTime DataAvalicao {get; set;} = DateTime.Now;

    public Avaliacao(Jogo jogo, int nota, string autor)
    {
        if (jogo==null)
            throw new ArgumentNullException("O jogo não pode ser nulo");
        if (nota < 0 || nota > 10)
            throw new ArgumentOutOfRangeException("A nota deve estar entre 0 e 10");
        if (string.IsNullOrWhiteSpace(autor))
            throw new ArgumentException("O nome não pode ser nulo");

        this.Jogo = jogo;
        this.JogoId = jogo.Id;
        this.Nota = nota;
        this.Autor = autor;
    }

    public override string ToString()
        {
            string comentario = string.IsNullOrWhiteSpace(Comentario) ? "(sem comentario)" : Comentario;
            return $"Nota: {Nota}/10 | Por: {Autor} | Em: {DataAvalicao:dd/MM/yyyy HH:mm} | Comentario: {comentario}";
        }
    }
