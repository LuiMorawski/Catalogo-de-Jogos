## 1. Descrição do sistema

O sistema é um catálogo de jogos que permite cadastrar jogos, avaliá-los (nota de 0 a 10 + comentário) e calcular automaticamente um ranking dos jogos mais bem avaliados. O usuário interage por meio de um menu no console.

---

## 2. Diagrama de classes (visão geral)


Program
  |
  +--- CatalogoService
          |
          +--- List<Jogo>
          |        |
          |        +--- Genero (enum)
          |        +--- Plataforma (enum)
          |        +--- List<Avaliacao>
          |                 |
          |                 +--- Usuario
          |
          +--- List<Usuario>


- Jogo *possui* uma lista de Avaliacao (relacionamento 1 para N).
- Avaliacao *referencia* um Usuario (relacionamento N para 1 — vários jogos podem ter avaliações do mesmo usuário).
- Jogo *tem* um Genero e uma Plataforma (enums, não classes).
- CatalogoService *gerencia* a List<Jogo> e a List<Usuario> do sistema.

---

## 3. Classes de modelo

### 3.1 Jogo (classe principal)

Representa um jogo cadastrado no catálogo.

| Atributo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador único, gerado automaticamente |
| Titulo | string | Nome do jogo |
| Genero | Genero (enum) | Gênero do jogo |
| Plataforma | Plataforma (enum) | Plataforma do jogo |
| Avaliacoes | List<Avaliacao> | Lista de avaliações recebidas (relacionamento com Avaliacao) |

*Construtor:* Jogo(int id, string titulo, Genero genero, Plataforma plataforma)

*Métodos:*
- UsuarioJaAvaliou(Usuario usuario) → bool: verifica se um usuário já avaliou este jogo (suporta a regra de negócio de avaliação única).
- AdicionarAvaliacao(Avaliacao avaliacao): adiciona uma avaliação à lista.
- MediaAvaliacoes() → double: calcula a média das notas recebidas (regra de negócio usada no ranking).
- ToString(): formata a exibição do jogo no console.

---

### 3.2 Avaliacao

Representa a avaliação de um jogo feita por um usuário.

| Atributo | Tipo | Descrição |
|---|---|---|
| Usuario | Usuario | Usuário que fez a avaliação (relacionamento com Usuario) |
| Nota | int | Nota de 0 a 10 |
| Comentario | string | Comentário opcional sobre o jogo |
| Data | DateTime | Data em que a avaliação foi registrada |

*Construtor:* Avaliacao(Usuario usuario, int nota, string comentario)
- Valida a nota: lança ArgumentException se nota < 0 ou nota > 10 (regra de negócio).

---

### 3.3 Usuario

Representa a pessoa que avalia jogos.

| Atributo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador único, gerado automaticamente |
| Nome | string | Nome do usuário |

*Construtor:* Usuario(int id, string nome)

---

### 3.4 Genero (enum)

Valores: Acao, Aventura, RPG, Esporte, Estrategia, Simulacao, Corrida, Terror, Puzzle, Outro

### 3.5 Plataforma (enum)

Valores: PC, PS5, PS4, XboxSeriesX, XboxOne, NintendoSwitch, Mobile

---

## 4. Classe de serviço

### CatalogoService

Não é uma classe de modelo — organiza as regras de negócio e as listas do sistema, separando essa lógica da interface de console (Program).

| Atributo | Tipo | Descrição |
|---|---|---|
| jogos | List<Jogo> | Todos os jogos cadastrados |
| usuarios | List<Usuario> | Todos os usuários que já avaliaram algum jogo |
| proximoIdJogo / proximoIdUsuario | int | Contadores internos para gerar Ids |

*Principais métodos:*
- CadastrarJogo(titulo, genero, plataforma) — valida título vazio e título duplicado.
- ListarJogos()
- BuscarJogoPorId(id) / BuscarJogosPorTitulo(termo)
- RemoverJogo(id)
- ObterOuCriarUsuario(nome) — reaproveita o usuário se o nome já existir.
- AvaliarJogo(idJogo, nomeUsuario, nota, comentario) — aplica a regra de "uma avaliação por usuário por jogo".
- ObterRanking() — retorna os jogos ordenados pela média de avaliações (do maior para o menor).

---

## 5. Relacionamentos entre objetos

| Relação | Tipo | Como é representado no código |
|---|---|---|
| Jogo → Avaliacao | 1 para N | Jogo.Avaliacoes (List<Avaliacao>) |
| Avaliacao → Usuario | N para 1 | Avaliacao.Usuario (referência direta ao objeto) |
| CatalogoService → Jogo | 1 para N | List<Jogo> |
| CatalogoService → Usuario | 1 para N | List<Usuario> |

---

## 6. Regras de negócio implementadas

1. *Validação de nota:* a nota de uma avaliação deve estar entre 0 e 10 (Avaliacao).
2. *Título único:* não é permitido cadastrar dois jogos com o mesmo título (CatalogoService.CadastrarJogo).
3. *Avaliação única por usuário:* um mesmo usuário não pode avaliar o mesmo jogo mais de uma vez (Jogo.UsuarioJaAvaliou).
4. *Cálculo de ranking:* os jogos são ordenados pela média das notas recebidas (Jogo.MediaAvaliacoes + CatalogoService.ObterRanking).

---

## 7. Menu do sistema (console)


========================================
        CATALOGO DE JOGOS
========================================
1 - Cadastrar jogo
2 - Listar jogos
3 - Buscar jogo por titulo
4 - Remover jogo
5 - Avaliar jogo
6 - Exibir ranking dos mais bem avaliados
0 - Sair
========================================


Cada opção chama um método correspondente em Program.cs, que por sua vez usa o CatalogoService para manipular as listas de Jogo e Usuario.

---

## 8. Estrutura de arquivos do projeto


CatalogoJogos/
 ├── CatalogoJogos.csproj
 ├── Program.cs
 ├── README.md
 ├── Models/
 │    ├── Jogo.cs
 │    ├── Avaliacao.cs
 │    ├── Usuario.cs
 │    ├── Genero.cs
 │    └── Plataforma.cs
 └── Services/
      └── CatalogoService.cs