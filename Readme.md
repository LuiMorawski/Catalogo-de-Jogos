<div align="center">

# 🎮 Catálogo de Jogos

### Sistema de cadastro, avaliação e ranking de jogos em C#

![C#](https://img.shields.io/badge/C%23-.NET%208-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Console App](https://img.shields.io/badge/Tipo-Console%20App-2b2d42?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Concluído-4CAF50?style=for-the-badge)

</div>

---

📚 Sobre o projeto

O Catálogo de Jogos é uma aplicação de console desenvolvida em C# (.NET 8) para a disciplina de Desenvolvimento de Software Visual, sob orientação do Prof. Marlon, como parte da atividade A2-1.

O sistema permite:

🕹️ Cadastrar jogos (com título, ano de lançamento e gênero)
⭐ Avaliá-los com nota (0 a 10) e comentário
🔍 Buscar jogos por título
🗑️ Remover jogos
🏆 Calcular automaticamente um ranking dos jogos mais bem avaliados

Toda a interação acontece por meio de um menu no console.

🧩 Diagrama de classes (visão geral)
Program
  │
  └── CatalogoServices
        │
        ├── List<Jogo>
        │      │
        │      ├── Genero (1:N — um gênero pode ter vários jogos)
        │      ├── List<JogoPlataforma> (N:N com Plataforma, via classe de junção)
        │      └── List<Avaliacao>
        │
        └── List<Genero>
Relação	Cardinalidade	Descrição
Jogo → Avaliacao	1 : N	Um jogo possui várias avaliações
Genero → Jogo	1 : N	Um gênero pode estar associado a vários jogos
Jogo ↔ Plataforma	N : N	Um jogo pode ter várias plataformas e vice-versa, via JogoPlataforma
🏗️ Estrutura de arquivos
CatalogoJogos/
 ├── CatalogoJogos.csproj
 ├── Program.cs
 ├── README.md
 ├── Models/
 │    ├── Jogo.cs
 │    ├── Avaliacao.cs
 │    ├── Genero.cs
 │    ├── Plataforma.cs
 │    └── JogoPlataforma.cs
 └── Services/
      └── CatalogoServices.cs
🧱 Classes de modelo
🎮 Jogo

Representa um jogo cadastrado no catálogo.

Atributo	Tipo	Descrição
Id	int	Identificador único, gerado automaticamente
Titulo	string	Nome do jogo
AnoLancamento	int	Ano de lançamento do jogo
DataCadastro	DateTime	Preenchida automaticamente no momento do cadastro
GeneroId / Genero	int / Genero	Gênero do jogo (relação 1:N)
JogoPlataformas	List<JogoPlataforma>	Plataformas vinculadas ao jogo (relação N:N)
Avaliacoes	List<Avaliacao>	Lista de avaliações recebidas

Construtor

csharp
Jogo(string titulo, int anoLancamento, Genero genero)

Métodos

Método	Retorno	Descrição
AdicionarPlataforma(Plataforma plataforma)	void	Vincula uma plataforma ao jogo, evitando duplicidade
AdicionarAvaliacao(Avaliacao avaliacao)	void	Adiciona uma avaliação, impedindo que o mesmo autor avalie duas vezes
CalcularMediaAvaliacoes()	double	Calcula a média das notas recebidas
⭐ Avaliacao

Representa a avaliação de um jogo feita por um autor.

Atributo	Tipo	Descrição
Id	int	Identificador único
JogoId / Jogo	int / Jogo	Jogo avaliado
Nota	int	Nota de 0 a 10
Autor	string	Nome de quem avaliou
Comentario	string	Comentário opcional sobre o jogo
DataAvaliacao	DateTime	Preenchida automaticamente

Construtor

csharp
Avaliacao(Jogo jogo, int nota, string autor)

⚠️ Lança ArgumentException se nota < 0 ou nota > 10.

🗂️ Genero

Representa o gênero de um jogo.

Atributo	Tipo	Descrição
Id	int	Identificador único
Nome	string	Nome do gênero (ex: Ação, RPG, Terror)
Jogos	List<Jogo>	Jogos cadastrados nesse gênero

Construtores

csharp
Genero()              // gênero vazio
Genero(string nome)   // gênero com nome definido

Gêneros são reaproveitados automaticamente: ao cadastrar um jogo, o sistema busca se já existe um gênero com aquele nome (ignorando maiúsculas/minúsculas) antes de criar um novo.

🎛️ Plataforma / JogoPlataforma
<table> <tr> <td valign="top">

Plataforma

Atributo	Tipo
Id	int
Nome	string
JogoPlataformas	List<JogoPlataforma>
</td> <td valign="top">

JogoPlataforma (classe de junção)

Atributo	Tipo
JogoId / Jogo	int / Jogo
PlataformaId / Plataforma	int / Plataforma
</td> </tr> </table>

Modelada com relação N:N em relação a Jogo, através da classe de junção JogoPlataforma.

ℹ️ Nota: a estrutura de dados e os métodos de vínculo (AdicionarPlataforma) já estão implementados, mas o menu de console ainda não oferece uma opção para cadastrar a plataforma de um jogo. Fica como funcionalidade pronta para uma próxima etapa.

⚙️ Classe de serviço — CatalogoServices

Organiza as regras de negócio e as listas do sistema, separando essa lógica da interface de console (Program).

Atributo	Tipo	Descrição
jogos	List<Jogo>	Todos os jogos cadastrados
generos	List<Genero>	Todos os gêneros já criados
proximoId / proximoIdGenero	int	Contadores internos para gerar Ids

Principais métodos

Método	Descrição
CadastrarJogo(titulo, ano, genero)	Cadastra um novo jogo e sincroniza a lista do gênero
ObterOuCriarGenero(nome)	Reaproveita o gênero se o nome já existir, senão cria um novo
ListarJogos()	Lista todos os jogos cadastrados, com gênero
BuscarJogo(busca)	Busca jogos cujo título contenha o termo digitado
BuscarJogoPorId(id)	Busca um jogo pelo Id
RemoverJogo(id)	Remove um jogo do catálogo
AvaliarJogo(idJogo, autor, nota, comentario)	Aplica a regra de "uma avaliação por autor por jogo"
ExibirRanking()	Exibe os jogos ordenados pela média de avaliações (maior → menor)
✅ Regras de negócio implementadas
 Validação de nota — a nota de uma avaliação deve estar entre 0 e 10 (Avaliacao)
 Avaliação única por autor — um mesmo autor não pode avaliar o mesmo jogo mais de uma vez (Jogo.AdicionarAvaliacao)
 Reaproveitamento de gênero — gêneros com o mesmo nome (ignorando maiúsculas/minúsculas) não são duplicados (CatalogoServices.ObterOuCriarGenero)
 Cálculo de ranking — os jogos são ordenados pela média das notas recebidas (Jogo.CalcularMediaAvaliacoes + CatalogoServices.ExibirRanking)
🛡️ Tratamento de erros

Todas as opções do menu que dependem de entrada numérica do usuário (int.Parse) estão protegidas com try/catch, evitando que o programa encerre inesperadamente ao digitar um valor inválido:

Leitura da opção do menu
Cadastro de jogo (ano)
Remoção de jogo (Id)
Avaliação de jogo (Id e nota)
🖥️ Menu do sistema
╔═══════════════════════════╗
║           MENU            ║
╠═══════════════════════════╣
║ 1 - Cadastrar jogo        ║
║ 2 - Listar jogos          ║
║ 3 - Buscar jogo por titulo║
║ 4 - Remover jogo          ║
║ 5 - Avaliar jogo          ║
║ 6 - Exibir ranking        ║
║ 0 - Sair                  ║
╚═══════════════════════════╝

Cada opção chama um método correspondente em Program.cs, que por sua vez usa o CatalogoServices para manipular as listas de Jogo e Genero.

<div align="center">
🏫 Informações acadêmicas
	
Disciplina	Desenvolvimento de Software Visual
Professor	Marlon
Atividade	A2-1 — Desenvolvimento de um sistema em C#
Tecnologia	C# (.NET 8) — Aplicação Console
</div>

👨‍💻 Autores
Luiz
Nathan
Erick
