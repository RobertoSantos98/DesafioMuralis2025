Desafio Muralis 2025 - API de Clientes (RobertoSantos98)
Esta é a API RESTful desenvolvida como solução para o Desafio C# da Muralis. 


O objetivo principal desta API é fornecer um sistema para o gerenciamento completo (CRUD) de Clientes, incluindo seus respectivos Endereços e Contatos, seguindo a modelagem de dados proposta. 

🛠️ Stack Tecnológico

.NET Core (versões mais recentes) 


Entity Framework Core (para persistência de dados) 

PostgreSQL (Banco de dados)


API RESTful (Arquitetura) 


Mapeamento com DTOs (Request/Response) 

🚀 Começando
Siga estas instruções para obter uma cópia funcional do projeto em sua máquina local para desenvolvimento e testes.

1. Pré-requisitos
Antes de começar, certifique-se de que você tem as seguintes ferramentas instaladas:

.NET SDK (Recomendado: .NET 6, 7 ou 8)

Git

Um servidor PostgreSQL ativo.

Um editor de código, como Visual Studio Code ou Visual Studio 2022.

2. Clonando o Repositório (Git)
Use o Git para clonar este repositório para sua máquina local.


# Clone o repositório
```Bash
git clone https://github.com/RobertoSantos98/DesafioMuralis2025.git
```

# Navegue para a pasta do projeto
cd DesafioMuralis2025
3. Configurando o Banco de Dados (String de Conexão)
Esta API usa PostgreSQL. Você precisa configurar a string de conexão para que a API possa encontrar seu banco de dados.

Crie o Banco de Dados: Abra sua ferramenta de gerenciamento do PostgreSQL (como DBeaver ou pgAdmin) e crie um novo banco de dados. O nome padrão sugerido é DesafioMuralis.

Edite o appsettings.json: Abra o arquivo appsettings.json (ou appsettings.Development.json) localizado no projeto principal da API.

Ajuste a ConnectionStrings: Localize a seção ConnectionStrings e edite a DefaultConnection com suas credenciais locais do PostgreSQL.

```json

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=DesafioMuralis;Username=postgres;Password=admin"
}
```

Host: O endereço do seu servidor (normalmente localhost).

Database: O nome do banco que você criou no passo 1.

Username: Seu usuário do PostgreSQL (o padrão costuma ser postgres).

Password: Sua senha do PostgreSQL.

4. Aplicando as Migrações (Entity Framework)
Com a string de conexão configurada, você precisa criar a estrutura das tabelas (Clientes, Enderecos, Contatos) no seu banco.

O projeto usa o Entity Framework Core Migrations para gerenciar o esquema do banco. 

Abra um terminal na pasta raiz do projeto da API (o projeto que contém o arquivo Program.cs e appsettings.json).

Execute o comando database update: Este comando irá ler os arquivos de migração existentes no projeto e aplicá-los ao seu banco de dados, criando todas as tabelas e relacionamentos.


# Se o seu DbContext (ex: AppDbContext) está no mesmo projeto da API
```Bash
dotnet ef database update
```

Nota: Se o seu DbContext estiver em um projeto de biblioteca de classes separado (ex: DesafioMuralis2025.Infrastructure), você deve executar o comando a partir da pasta da API, mas apontando para o projeto de infra:


# Exemplo se o DbContext estiver em um projeto .Infrastructure

```Bash
dotnet ef database update --project ../DesafioMuralis2025.Infrastructure
```

Após o comando ser executado com sucesso, seu banco de dados estará populado com as tabelas necessárias.

🏃‍♀️ Rodando a API
Com o banco de dados pronto, você pode iniciar a aplicação.

Execute o projeto: Ainda no terminal, na pasta do projeto da API, execute:

```Bash

dotnet run
```

Acesse a API: A API estará rodando. O terminal mostrará as URLs (ex: http://localhost:5123 e https://localhost:7123).

📖 Acessando o Swagger (Documentação Interativa)
Este projeto vem configurado com o Swagger (OpenAPI) para documentação e testes interativos da API.

Após executar a aplicação (com dotnet run), abra a URL do Swagger no seu navegador. Geralmente, ela estará disponível em:

httpsa://localhost:<SUA_PORTA_HTTPS>/swagger

(Exemplo: https://localhost:7123/swagger)

Você verá uma interface onde poderá ver todos os endpoints, seus modelos (DTOs) e executá-los diretamente pelo navegador.

🧪 Testando os Endpoints
Para testar os endpoints, você pode usar uma ferramenta como o Postman ou Insomnia.  Os endpoints implementados seguem os requisitos do desafio:

POST /api/clientes - Cadastra um novo cliente.

GET /api/clientes - Lista todos os clientes.

GET /api/clientes/{id} - Consulta um cliente específico.

GET /api/clientes/buscar?termo=... - Pesquisa clientes.

PUT /api/clientes/{id} - Altera um cliente existente.

DELETE /api/clientes/{id} - Exclui um cliente.

## 📦 Endpoints principais

### 1️⃣ Criar cliente
**POST** `/api/clientes`

**Corpo (JSON)**:
```json
{
  "nome": "Nome do Cliente",
  "endereco": {
    "cep": "12345678",
    "numero": "123",
    "complemento": "Apt 45"
  },
  "contatos": [
    { "tipo": "Email", "texto": "cliente@exemplo.com" },
    { "tipo": "Telefone", "texto": "11999999999" }
  ]
}
```

**Resposta (sucesso)**:
```json
{
  "success": true,
  "data": {
    "id": 1,
    "nome": "Nome do Cliente",
    "endereco": {
      "cep": "12345678",
      "logradouro": "Rua X",
      "cidade": "Cidade Y",
      "numero": "123",
      "complemento": "Apt 45",
      "dataCadastro": "2025-10-30"
    },
    "contatos": [
      { "tipo": "Email", "texto": "cliente@exemplo.com" },
      { "tipo": "Telefone", "texto": "11999999999" }
    ]
  },
  "errors": null
}
```

### 2️⃣ Obter todos os clientes
**GET** `/api/clientes`

**Resposta (sucesso)**:
```json
{
  "success": true,
  "data": [
    {
      "id": 1,
      "nome": "Nome do Cliente",
      "endereco": { /* endereço completo */ },
      "contatos": [ /* lista de contatos */ ]
    },
    {
      "id": 2,
      "nome": "Outro Cliente",
      "endereco": { /* endereço completo */ },
      "contatos": [ /* lista de contatos */ ]
    }
  ],
  "errors": null
}
```

### 3️⃣ Obter cliente por ID
**GET** `/api/clientes/{id}`

**Resposta (sucesso)**:
```json
{
  "success": true,
  "data": {
    "id": 1,
    "nome": "Nome do Cliente",
    "endereco": { /* endereço completo */ },
    "contatos": [ /* lista de contatos */ ]
  },
  "errors": null
}
```

**Resposta (falha: não encontrado)**:
```json
{
  "success": false,
  "data": null,
  "errors": ["Cliente não encontrado."]
}
```

### 4️⃣ Atualizar cliente
**PUT** `/api/clientes/{id}`

**Corpo (JSON)**:
```json
{
  "id": 1,
  "nome": "Nome Atualizado",
  "endereco": {
    "cep": "12345678",
    "numero": "321",
    "complemento": "Apt 55"
  },
  "contatos": [
    { "tipo": "Email", "texto": "novoemail@exemplo.com" },
    { "tipo": "Telefone", "texto": "11988888888" }
  ]
}
```

**Resposta (sucesso)**:
```json
{
  "success": true,
  "data": {
    "id": 1,
    "nome": "Nome Atualizado",
    "endereco": { /* endereço atualizado */ },
    "contatos": [ /* lista de contatos atualizada */ ]
  },
  "errors": null
}
```

**Resposta (falha: não encontrado)**:
```json
{
  "success": false,
  "data": null,
  "errors": ["Cliente não encontrado."]
}
```

### 5️⃣ Excluir cliente
**DELETE** `/api/clientes/{id}`

**Resposta (sucesso)**:
```json
{
  "success": true,
  "data": null,
  "errors": null
}
```

**Resposta (falha)**:
```json
{
  "success": false,
  "data": null,
  "errors": ["Erro ao excluir o cliente."]
}
```

---

## 🎯 Regras de negócio

- `DataCadastro` é definido automaticamente e não pode ser alterado.
- Endereço é buscado via provedor de CEP externo; se não encontrado, criação/atualização falha.
- `GetById` e `GetAll` incluem endereço e contatos na resposta.

---

## 🧪 Testes e uso local

- Teste endpoints via Swagger ou Postman.
- Modifique banco local e reinicie API conforme necessário.
- Adicione logging ou tratamento de exceções para a API externa.

---

## 🔧 Customizações futuras

- Paginação no `GetAll`
- Filtros por nome, cidade ou tipo de contato
- Autenticação e autorização (JWT)
- Cache para CEPs ou clientes consultados frequentemente
- Histórico de alterações do cliente (audit log)
