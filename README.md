🐾 Pet Shop API - Sistema de Gerenciamento Backend

- Esta API RESTful foi desenvolvida para gerenciar as operações principais de um Pet Shop, incluindo o controle de tutores, pets, agendamento de serviços (visitas) e fluxo de vendas (pedidos). O projeto foca em alta performance, código limpo e escalabilidade.

Arquitetura e Padrões de Projeto
O sistema foi estruturado seguindo os princípios de Clean Architecture e Domain-Driven Design (DDD), garantindo a separação de responsabilidades:

Domain: Contém as entidades de negócio, enums e interfaces de repositórios. É o núcleo do sistema, livre de dependências externas.

Application: Camada responsável pela lógica de aplicação e orquestração de serviços.

Infrastructure: Implementação da persistência de dados utilizando Dapper (Micro-ORM) para consultas SQL otimizadas e conexão com PostgreSQL.

API: Camada de interface REST com controllers documentados via Swagger e uso de DTOs (Data Transfer Objects) para segurança e suporte a atualizações parciais.

Tech Stack
Linguagem: C# (.NET 8)

Acesso a Dados: Dapper

Banco de Dados: PostgreSQL

Documentação: Swagger (OpenAPI)

Arquitetura: DDD, Repository Pattern, Injeção de Dependência.

Funcionalidades Principais
Gestão de Visitas: Sistema de agendamento com fluxo de status dinâmico (Agendado, Em Andamento, Finalizada, Cancelada).

Atualizações Parciais: Uso de DTOs com propriedades anuláveis para permitir a alteração de campos específicos sem afetar o restante do registro.

Fluxo de Pedidos: Gerenciamento de vendas vinculando produtos, serviços, tutores e itens de pedido com cálculo automático de valores.

Integridade de Dados: Modelagem relacional robusta com chaves estrangeiras e restrições de banco de dados.

Estrutura do Banco de Dados
O banco de dados PostgreSQL foi modelado para suportar o crescimento do negócio:

usuario: Gerenciamento de tutores e perfis de acesso.

pet: Cadastro de animais vinculados aos seus tutores.

visita: Controle de agenda com status e valores.

servico / produto: Catálogo de itens disponíveis.

pedido / item_pedido: Registro de transações financeiras.

Como Executar
Clone o repositório:

  Bash
  git clone https://github.com/PamFreitaz/PetShop-API.git
  
Configure o Banco de Dados:

Certifique-se de ter o PostgreSQL rodando.

Execute os scripts de criação de tabelas localizados em /Infrastructure/Scripts.

Ajuste a Connection String:

No arquivo appsettings.json, insira suas credenciais do banco.

Inicie a API:

Bash
dotnet run --project Pet.WebAPI
Acesse o Swagger:

Abra https://localhost:7013/swagger no seu navegador.

Autora
Pâmela

Desenvolvedora Backend focada em ecossistemas .NET e Java.
