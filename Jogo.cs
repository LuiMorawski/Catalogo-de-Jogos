using System;
using System.Collections.Generic;

public class Jogo
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int AnoLancamento { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public int GeneroId { get; set; }
    public Genero Genero { get; set; }

    public List<JogoPlataforma> JogoPlataformas { get; set; } = new();
    public List<Avaliacao> Avaliacoes { get; set; } = new();

    public Jogo(string titulo, int anoLancamento, Genero genero)
    {
        this.Titulo = titulo;
        this.AnoLancamento = anoLancamento;
        this.Genero = genero;
        this.GeneroId = genero.Id;
    }

    public bool JaAvaliadoPor(string autor)
    {
        foreach (var avaliacao in Avaliacoes)
        {
            if (avaliacao.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public double MediaAvaliacoes()
    {
        if (Avaliacoes.Count == 0) return 0;

        int soma = 0;
        foreach (var avaliacao in Avaliacoes)
        {
            soma = soma + avaliacao.Nota;
        }

        return (double)soma / Avaliacoes.Count;
    }

    public string NomesPlataformas()
    {
        if (JogoPlataformas.Count == 0) return "(nenhuma)";

        string resultado = "";
        for (int i = 0; i < JogoPlataformas.Count; i++)
        {
            resultado = resultado + JogoPlataformas[i].Plataforma.Nome;

            if (i < JogoPlataformas.Count - 1)
            {
                resultado = resultado + ", ";
            }
        }
        return resultado;
    }

    public override string ToString()
    {
        string media;
        if (Avaliacoes.Count == 0)
        {
            media = "sem avaliacoes";
        }
        else
        {
            media = $"{MediaAvaliacoes():F1}/10 ({Avaliacoes.Count} avaliacao(oes))";
        }

        return $"[{Id}] {Titulo} ({AnoLancamento}) | Genero: {Genero.Nome} | Plataformas: {NomesPlataformas()} | Media: {media}";
    }
}