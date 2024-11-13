# Agendamento de Banho e Tosa - Minimal API em C#

Este projeto é uma Minimal API em C# para gerenciamento de agendamentos de serviços de banho e tosa de animais de estimação. O sistema permite que clientes agendem serviços específicos para seus animais, como banho, tosa, entre outros.

## Funcionalidades

1. **Cadastro de Clientes**: Gerencia informações dos clientes, como nome, telefone e endereço.
2. **Cadastro de Animais**: Registra animais de estimação, incluindo dados como nome, tipo de animal (ex: cão, gato) e associação com o dono.
3. **Gerenciamento de Serviços**: Define serviços oferecidos, incluindo nome e preço.
4. **Agendamento de Serviços**: Cria, consulta, atualiza e exclui agendamentos, permitindo que clientes escolham o serviço desejado, associem o animal e selecionem a data/hora.

## Estrutura de Arquivos e Pastas

A estrutura principal do projeto é baseada no padrão MVC, com uma API mínima em C#. Os componentes principais são:
[Em planejamento pode ser alterado a qualquer momento]
```
📂 ProjetoRaiz 
  ├── 📂 Models # Classes que representam as entidades (Cliente, Animal, Servico, Agendamento) 
  ├── 📂 Data # Classe DbContext que mapeia as Classes de Model para o Banco de dados (EF + Banco Postgres [NpgSql.EntityFrameWorkCore.PostgreSql]) 
  ├── 📂 Services # Lógica de negócios para cada entidade 
  ├── 📂 Controllers # Mapeamento dos endpoints para CRUD 
  └── Program.cs # Configuração da API e mapeamento de endpoints (pode mudar)
```


## Estrutura de Classes

### Models

- **Cliente**: Representa o cliente do serviço, com atributos `Id`, `Nome`, `Telefone`, `Endereco`.
- **Animal**: Representa o animal de estimação, com atributos `Id`, `Nome`, `Tipo` e o `ClienteId` que o associa ao seu dono.
- **Servico**: Representa o tipo de serviço oferecido, com `Id`, `Nome` e `Preco`.
- **Agendamento**: Representa um agendamento de serviço, associando `Cliente`, `Animal`, `Servico` e `DataHora` para o agendamento.



### Controllers

Os controladores expõem os endpoints da API e mapeiam as operações para cada entidade. No padrão Minimal API, o mapeamento é feito em uma única classe que organiza os endpoints para cada recurso:

- **ClienteController**: Endpoints para CRUD de clientes.
- **AnimalController**: Endpoints para manipulação de dados dos animais.
- **ServicoController**: Endpoints para gerenciar tipos de serviços.
- **AgendamentoController**: Endpoints para criação, listagem e cancelamento de agendamentos.

### Exemplo de Endpoint (ClienteController)

```csharp
// Endpoint para listar todos os clientes
app.MapGet("/clientes", async (HttpContext context) =>
{
    var clientes = await _clienteService.GetAllClientesAsync();
    await context.Response.WriteAsJsonAsync(clientes);
});

// Endpoint para criar um novo cliente
app.MapPost("/clientes", async (HttpContext context) =>
{
    var cliente = await context.Request.ReadFromJsonAsync<Cliente>();
    await _clienteService.AddClienteAsync(cliente);
    context.Response.StatusCode = StatusCodes.Status201Created;
    await context.Response.WriteAsJsonAsync(cliente);
});


