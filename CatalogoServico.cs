using System;
using System.Collections.Generic;

public class CatalogoServico
{
    private List<Jogo> jogos = new List<Jogo>();
    private List<Genero> generos = new List<Genero>();
    private List<Plataforma> plataformas = new List<Plataforma>();

    private int proximoIdJogo = 1;
    private int proximoIdGenero = 1;
    private int proximoIdPlataforma = 1;
    private int proximoIdAvaliacao = 1;

    public Genero ObterOuCriarGenero(string nome)
    {
        foreach (var genero in generos)
        {
            if (genero.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return genero;
            }
        }

        var novoGenero = new Genero(nome);
        novoGenero.Id = proximoIdGenero;
        proximoIdGenero++;
        generos.Add(novoGenero);
        return novoGenero;
    }

    public Plataforma ObterOuCriarPlataforma(string nome)
    {
        foreach (var plataforma in plataformas)
        {
            if (plataforma.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return plataforma;
            }
        }

        var novaPlataforma = new Plataforma(nome);
        novaPlataforma.Id = proximoIdPlataforma;
        proximoIdPlataforma++;
        plataformas.Add(novaPlataforma);
        return novaPlataforma;
    }

    public Jogo CadastrarJogo(string titulo, int anoLancamento, string nomeGenero, List<string> nomesPlataformas)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O titulo nao pode ser vazio.");

        foreach (var jogoExistente in jogos)
        {
            if (jogoExistente.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Ja existe um jogo cadastrado com esse titulo.");
            }
        }

        if (nomesPlataformas == null || nomesPlataformas.Count == 0)
            throw new ArgumentException("Informe ao menos uma plataforma.");

        var genero = ObterOuCriarGenero(nomeGenero);

        var jogo = new Jogo(titulo, anoLancamento, genero);
        jogo.Id = proximoIdJogo;
        proximoIdJogo++;

        foreach (var nomePlataforma in nomesPlataformas)
        {
            var plataforma = ObterOuCriarPlataforma(nomePlataforma);
            jogo.JogoPlataformas.Add(new JogoPlataforma(jogo, plataforma));
        }

        jogos.Add(jogo);
        return jogo;
    }

    public List<Jogo> ListarJogos()
    {
        return jogos;
    }

    public Jogo BuscarJogoPorId(int id)
    {
        foreach (var jogo in jogos)
        {
            if (jogo.Id == id)
            {
                return jogo;
            }
        }
        return null;
    }

    public List<Jogo> BuscarJogosPorTitulo(string termo)
    {
        var resultado = new List<Jogo>();

        foreach (var jogo in jogos)
        {
            if (jogo.Titulo.Contains(termo, StringComparison.OrdinalIgnoreCase))
            {
                resultado.Add(jogo);
            }
        }

        return resultado;
    }

    public bool RemoverJogo(int id)
    {
        var jogo = BuscarJogoPorId(id);
        if (jogo == null) return false;

        jogos.Remove(jogo);
        return true;
    }

    public Avaliacao AvaliarJogo(int idJogo, string autor, int nota, string comentario)
    {
        var jogo = BuscarJogoPorId(idJogo);
        if (jogo == null)
            throw new ArgumentException("Jogo nao encontrado.");

        if (jogo.JaAvaliadoPor(autor))
            throw new InvalidOperationException("Este usuario ja avaliou este jogo.");

        var avaliacao = new Avaliacao(jogo, nota, autor);
        avaliacao.Id = proximoIdAvaliacao;
        proximoIdAvaliacao++;
        avaliacao.Comentario = comentario;

        jogo.Avaliacoes.Add(avaliacao);
        return avaliacao;
    }

    public List<Jogo> ObterRanking()
    {
        var ranking = new List<Jogo>(jogos);

        for (int i = 0; i < ranking.Count - 1; i++)
        {
            int indiceDoMaior = i;

            for (int j = i + 1; j < ranking.Count; j++)
            {
                if (ranking[j].MediaAvaliacoes() > ranking[indiceDoMaior].MediaAvaliacoes())
                {
                    indiceDoMaior = j;
                }
            }

            if (indiceDoMaior != i)
            {
                var jogoTemporario = ranking[i];
                ranking[i] = ranking[indiceDoMaior];
                ranking[indiceDoMaior] = jogoTemporario;
            }
        }

        return ranking;
    }
}