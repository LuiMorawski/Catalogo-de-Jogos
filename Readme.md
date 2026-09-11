<div align="center">

# 🎮 Catálogo de Jogos

### Sistema de cadastro, avaliação e ranking de jogos em C#

![C#](https://img.shields.io/badge/C%23-.NET%208-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Console App](https://img.shields.io/badge/Tipo-Console%20App-2b2d42?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Concluído-4CAF50?style=for-the-badge)

</div>

---

## 📚 Sobre o projeto

O **Catálogo de Jogos** é uma aplicação de console desenvolvida em **C# (.NET 8)** para a disciplina de **Desenvolvimento de Software Visual**, sob orientação do **Prof. Marlon**, como parte da atividade **A2-1**.

O sistema permite:

- 🕹️ Cadastrar jogos
- ⭐ Avaliá-los com nota (0 a 10) e comentário
- 🏆 Calcular automaticamente um **ranking dos jogos mais bem avaliados**

Toda a interação acontece por meio de um **menu no console**.

---

## 🧩 Diagrama de classes (visão geral)

```
Program
  │
  └── CatalogoService
        │
        ├── List<Jogo>
        │      │
        │      ├── Genero (enum)
        │      ├── Plataforma (enum)
        │      └── List<Avaliacao>
        │              │
        │              └── Usuario
        │
        └── List<Usuario>
```

| Relação | Cardinalidade | Descrição |
|---|:---:|---|
| `Jogo` → `Avaliacao` | 1 : N | Um jogo possui várias avaliações |
| `Avaliacao` → `Usuario` | N : 1 | Uma avaliação referencia um usuário |
| `Jogo` → `Genero` / `Plataforma` | 1 : 1 | Atributos do tipo enum |
| `CatalogoService` → `Jogo` / `Usuario` | 1 : N | Gerencia as listas do sistema |

---

## 🏗️ Estrutura de arquivos

```
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
```

---

## 🧱 Classes de modelo

### 🎮 `Jogo`

Representa um jogo cadastrado no catálogo.

| Atributo | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador único, gerado automaticamente |
| `Titulo` | `string` | Nome do jogo |
| `Genero` | `Genero` (enum) | Gênero do jogo |
| `Plataforma` | `Plataforma` (enum) | Plataforma do jogo |
| `Avaliacoes` | `List<Avaliacao>` | Lista de avaliações recebidas |

**Construtor**
```csharp
Jogo(int id, string titulo, Genero genero, Plataforma plataforma)
```

**Métodos**

| Método | Retorno | Descrição |
|---|---|---|
| `UsuarioJaAvaliou(Usuario usuario)` | `bool` | Verifica se o usuário já avaliou este jogo |
| `AdicionarAvaliacao(Avaliacao avaliacao)` | `void` | Adiciona uma avaliação à lista |
| `MediaAvaliacoes()` | `double` | Calcula a média das notas recebidas |
| `ToString()` | `string` | Formata a exibição do jogo no console |

---

### ⭐ `Avaliacao`

Representa a avaliação de um jogo feita por um usuário.

| Atributo | Tipo | Descrição |
|---|---|---|
| `Usuario` | `Usuario` | Usuário que fez a avaliação |
| `Nota` | `int` | Nota de 0 a 10 |
| `Comentario` | `string` | Comentário opcional sobre o jogo |
| `Data` | `DateTime` | Data em que a avaliação foi registrada |

**Construtor**
```csharp
Avaliacao(Usuario usuario, int nota, string comentario)
```
> ⚠️ Lança `ArgumentException` se `nota < 0` ou `nota > 10`.

---

### 👤 `Usuario`

Representa a pessoa que avalia jogos.

| Atributo | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador único, gerado automaticamente |
| `Nome` | `string` | Nome do usuário |

**Construtor**
```csharp
Usuario(int id, string nome)
```

---

### 🗂️ Enums

<table>
<tr>
<td valign="top">

**`Genero`**
- Acao
- Aventura
- RPG
- Esporte
- Estrategia
- Simulacao
- Corrida
- Terror
- Puzzle
- Outro

</td>
<td valign="top">

**`Plataforma`**
- PC
- PS5
- PS4
- XboxSeriesX
- XboxOne
- NintendoSwitch
- Mobile

</td>
</tr>
</table>

---

## ⚙️ Classe de serviço — `CatalogoService`

Organiza as regras de negócio e as listas do sistema, separando essa lógica da interface de console (`Program`).

| Atributo | Tipo | Descrição |
|---|---|---|
| `jogos` | `List<Jogo>` | Todos os jogos cadastrados |
| `usuarios` | `List<Usuario>` | Todos os usuários que já avaliaram algum jogo |
| `proximoIdJogo` / `proximoIdUsuario` | `int` | Contadores internos para gerar Ids |

**Principais métodos**

| Método | Descrição |
|---|---|
| `CadastrarJogo(titulo, genero, plataforma)` | Valida título vazio e título duplicado |
| `ListarJogos()` | Lista todos os jogos cadastrados |
| `BuscarJogoPorId(id)` | Busca um jogo pelo Id |
| `BuscarJogosPorTitulo(termo)` | Busca jogos pelo título |
| `RemoverJogo(id)` | Remove um jogo do catálogo |
| `ObterOuCriarUsuario(nome)` | Reaproveita o usuário se o nome já existir |
| `AvaliarJogo(idJogo, nomeUsuario, nota, comentario)` | Aplica a regra de "uma avaliação por usuário por jogo" |
| `ObterRanking()` | Retorna os jogos ordenados pela média de avaliações (maior → menor) |

---

## ✅ Regras de negócio implementadas

- [x] **Validação de nota** — a nota de uma avaliação deve estar entre 0 e 10 (`Avaliacao`)
- [x] **Título único** — não é permitido cadastrar dois jogos com o mesmo título (`CatalogoService.CadastrarJogo`)
- [x] **Avaliação única por usuário** — um mesmo usuário não pode avaliar o mesmo jogo mais de uma vez (`Jogo.UsuarioJaAvaliou`)
- [x] **Cálculo de ranking** — os jogos são ordenados pela média das notas recebidas (`Jogo.MediaAvaliacoes` + `CatalogoService.ObterRanking`)

---

## 🖥️ Menu do sistema

```
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
```

Cada opção chama um método correspondente em `Program.cs`, que por sua vez usa o `CatalogoService` para manipular as listas de `Jogo` e `Usuario`.

---

<div align="center">

### 🏫 Informações acadêmicas

| | |
|---|---|
| **Disciplina** | Desenvolvimento de Software Visual |
| **Professor** | Marlon |
| **Atividade** | A2-1 — Desenvolvimento de um sistema em C# |
| **Tecnologia** | C# (.NET 8) — Aplicação Console |

</div>