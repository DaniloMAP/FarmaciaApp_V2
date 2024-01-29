# Projeto FarmaciaApp

## Descrição
FarmaciaApp é um aplicativo web de gerenciamento de farmácia desenvolvido com ASP.NET Core e Entity Framework, utilizando PostgreSQL como banco de dados. O aplicativo permite o gerenciamento de medicamentos e reações adversas, incluindo funcionalidades como adição, remoção, edição e busca de medicamentos e reações adversas.

## Funcionalidades
- **Gerenciamento de Medicamentos**: Adicionar, editar, remover e visualizar medicamentos. Os detalhes incluem número de registro da Anvisa, nome, data de validade, telefone do SAC, preço, quantidade de comprimidos e fabricante.
- **Gerenciamento de Reações Adversas**: Adicionar, editar, remover e visualizar possíveis reações adversas dos medicamentos.
- **Pesquisa de Medicamentos**: Busca por nome ou número de registro da Anvisa.
- **Interface de Usuário Amigável**: Telas de cadastro com visualização gráfica e navegação intuitiva.

## Tecnologias Utilizadas
- **.NET 8.0**: Framework de desenvolvimento para construção de aplicativos web.
- **ASP.NET MVC**: Padrão de arquitetura para implementar interfaces de usuário.
- **Entity Framework Core**: ORM para acesso a dados.
- **PostgreSQL**: Sistema de gerenciamento de banco de dados.
- **Bootstrap**: Framework de front-end para design responsivo.
- **jQuery e jQuery Mask Plugin**: Para máscaras de entrada nos campos de formulários.

## Estrutura do Projeto
```
FarmaciaApp/
|-- Controllers/
|   |-- HomeController.cs
|   |-- MedicamentosController.cs
|   |-- ReacoesAdversasController.cs
|-- Models/
|   |-- Medicamento.cs
|   |-- ReacaoAdversa.cs
|   |-- Fabricante.cs
|   |-- MedicamentoReacaoAdversa.cs
|-- Views/
|   |-- Home/
|   |-- Medicamentos/
|   |-- ReacoesAdversas/
|-- wwwroot/
|   |-- css/
|   |-- js/
|   |-- lib/
|-- appsettings.json
|-- Program.cs
|-- Startup.cs
|-- FarmaciaApp.csproj
```

## Instalação e Execução
1. **Pré-requisitos**: Certifique-se de ter o .NET 8.0 SDK instalado.
2. **Clonar o Repositório**: `git clone [url-do-repositorio]`
3. **Restaurar Pacotes**: Execute `dotnet restore` dentro do diretório do projeto.
4. **Configurar Banco de Dados**: Atualize a string de conexão em `appsettings.json` para o seu PostgreSQL.
5. **Executar Migrações**: `dotnet ef database update`
6. **Iniciar a Aplicação**: Execute `dotnet run` dentro do diretório do projeto.
