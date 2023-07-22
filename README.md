# DSList-dotnet

[![.NET](https://github.com/kafziel4/dslist-dotnet/actions/workflows/dotnet.yml/badge.svg?event=push)](https://github.com/kafziel4/dslist-dotnet/actions/workflows/dotnet.yml)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white)

Durante o evento Intensivão Java Spring (10/07/23 - 14/07/23), o professor Nelio Alves apresentou um projeto de API REST chamado [DSList](https://github.com/devsuperior/dslist-backend).

Decidi reproduzir o projeto usando C#, ASP.NET Core 6.0 e Entity Framework Core 7.0 para treino. É um projeto simples que não leva em consideração alguns assuntos mais avançados, como tratamento de erros.

O projeto possui uma arquitetura em 3 camadas (controladores, serviços e acesso a dados) com um banco de dados SQLite para ambiente de desenvolvimento e um banco de dados PostgreSQL para ambiente de homologação/produção. Ele trabalha com 3 entidades, Game, GameList e Belonging, e permite:

- Buscar todos os Games.
- Buscar um Game por Id.
- Buscar todas as GameLists.
- Buscar os Games de uma GameList ordenados por posição.
- Alterar a posição de um Game na GameList.

Uma coleção do Postman está disponível para ser importada e realizar as chamadas.

O projeto foi construído usando TDD. Também possui testes de integração inicializando a aplicação em memória, com o PostgreSQL rodando em containers Docker descartáveis através da biblioteca [Testcontainers](https://dotnet.testcontainers.org/). Um workflow do GitHub Actions executa os testes em pull requests e pushes para a branch main.
