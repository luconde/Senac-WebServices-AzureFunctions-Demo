# Visão Geral
Este é um projeto de demonstração de desenvolvimento de microsserviços em C# e hospedagem no serviço Azure Functions.

Projeto construído para a disciplina **Desenvolvimento de WebServices** do curso **Tecnologia em Sistemas para Internet (TSI) do Senac-SP**.

# Autor
**Luciano Condé de Souza (luconde@gmail.com)**  
**Data da criação do projeto**: 2022-11-04  
**Data da última atualização**: 2023-05-26  
**Versão**: 1.5.1

## Disclaimer
O seguinte material foi construído a partir de referências publicadas na Internet, livros e artigos acadêmicos. As referências foram utilizadas de sites e posts na Internet, não há qualquer propósito de plagiar os autores, em caso de pedidos de adição do autor, pode encontrar em contato pelo email luconde@gmail.com. A simplificação de certos conteúdos tem o único propósito didático para facilitar o entendimento dos mesmos para os alunos.

# Notas da versão 
## Versão 1.5.1
1. Pasta **scripts** para armazenamento dos scripts Powershell para administração do ambiente
2. Pasta **src** para ter o código-fonte do projeto
3. Movimentação do código-fonte para dentro da pasta **src**
4. Adição do suporte à leitura do arquivo de configurações (settings.json)
5. Atualização e ajustes do arquivo README.md

# Detalhes técnicos

## Funcionalidades
1. Listar os conteúdos da tabela Categorias

## Pré-requisitos
1. Visual Studio 2022 Community
2. Azure SDK for Azure Functions
3. Pacote Nuget para Mysql
4. Banco MySql ja previamente preenchido

# Informações adicionais
Para pleno funcionamento, crie os arquivos settings.json (produção) e local.settings.json (ambiente de desenvolvimento) com base no template settings.json.template. 

No arquivo settings.json.template, configure a string de conexão para funcionamento com o banco de dados MySQL.

Este projeto considera que uma tabela chamada Categorias será acessada. Não há nenhum campo específico necessário para a tabela, pois o projeto fará uma consulta simples de SELECT *.