# Sistema de Agendamento de Banho e Tosa - UAU Dog - MVC API em C#

## Visão Geral do Projeto
O **Sistema de Agendamento de Banho e Tosa** foi desenvolvido para atender às necessidades do **UAU Dog**, um pet shop que oferece serviços de banho, tosa e clínica veterinária. O objetivo principal deste sistema é automatizar o agendamento de serviços para melhorar a organização e eficiência, além de registrar históricos de Tutores/clientes e animais.

O projeto foi estruturado de forma modular, permitindo fácil manutenção e expansão. No futuro, a API poderá ser estendida para abranger outros serviços veterinários, como vacinação, consultas e tratamentos especializados.

## Funcionalidades

1. **Cadastro de Tutores**: Gerencia informações dos Tutores, como nome, telefone e endereço.
  > - **Tutores**: Cadastro, consulta, edição e exclusão de Tutores.
2. **Cadastro de Animais**: Registra animais de estimação, incluindo dados como nome, tipo de animal (ex: cão, gato) e associação com o dono.
  > - **Animais**: Cadastro, consulta, edição e exclusão de Animais associados a clientes.
3. **Gerenciamento de Serviços**: Define serviços oferecidos, incluindo nome e preço.
  > - **Serviços**: Listagem de serviços oferecidos (banho, tosa, etc.).
4. **Agendamento de Serviços**: Cria, consulta, atualiza e exclui agendamentos, permitindo que clientes escolham o serviço desejado, associem o animal e selecionem a data/hora.
  > - **Agendamentos**: Criação, listagem, edição e exclusão de agendamentos para serviços.

## Estrutura de Arquivos e Pastas

A estrutura principal do projeto é baseada no padrão MVC, com uma API mínima em C#. Os componentes principais são:
[Em planejamento pode ser alterado a qualquer momento]
```
📂 ProjetoRaiz 
  ├── 📂 Models # Classes que representam as entidades (Cliente, Animal, Servico, Agendamento)
       ├── 📂 DTOs #  Classes de Transferencia de dados externos para o padrao da api
       ├── 📂 Entities # Entidades
       ├── 📂 Enums # ENUMS de Raça e especie
  ├── 📂 Data # Classe DbContext que mapeia as Classes de Model para o Banco de dados (EF + Banco Postgres [NpgSql.EntityFrameWorkCore.PostgreSql]) 
  ├── 📂 Services # Lógica de negócios para cada entidade 
  ├── 📂 Controllers # Mapeamento dos endpoints para CRUD
  ├── 📂 Migrations # Arquivos de migração do Entity Framework para banco Postgres AIVEN 
  └── Program.cs # Configuração da API e mapeamento de endpoints (pode mudar)
```

---

## Estrutura do Projeto
A estrutura do projeto foi projetada seguindo boas práticas de separação de responsabilidades:

- **Controller**: Controladores que gerenciam as rotas e a lógica das APIs.
  - `AgendamentoController.cs`: Gerencia os endpoints relacionados a agendamentos.
  - `ClienteController.cs`: Gerencia os endpoints relacionados a clientes.
  - `PetController.cs`: Gerencia os endpoints relacionados a pets.
  - `ServicoController.cs`: Gerencia os endpoints relacionados aos serviços.

- **Data**:
  - `AppDbContext.cs`: Classe de contexto que configura o Entity Framework e os mapeamentos para o banco de dados PostgreSQL.

- **Migrations**:
  - Armazena os arquivos de migração do Entity Framework.

- **Model**:
  - Contém as classes de domínio que representam os dados da aplicação:
  - 📂 Entities
    - `Agendamento.cs`
    - `Tutor.cs`
    - `Animal.cs`
    - `Servico.cs`
  - 📂 DTOS
    - `AgendamentoDTO.cs`
    - `TutorDTO.cs`
    - `AnimalDTO.cs`
    - `ServicoDTO.cs`
  - 📂 Enums
    - `ERacaCachorro.cs`
    - `ERacaGato.cs`
    - `ETipoPet.cs`

- **Services**:
  - Serviços responsáveis pela lógica de negócio:
    - `AgendamentoServ.cs`: Lida com a lógica de agendamentos.
    - `TutorServ.cs`: Gerencia operações relacionadas a clientes.
    - `AnimalServ.cs`: Gerencia operações relacionadas a pets.
    - `ServicoServ.cs`: Gerencia operações relacionadas aos serviços.

---

## Tecnologias Utilizadas
- **Framework**: .NET (C#)
- **Banco de Dados**: PostgreSQL (Serviço no AIVEN)
- **ORM**: Entity Framework Core
- **Documentação**: Swagger para API
- **Gerenciamento de Dependências**: Injeção de Dependência (DI) nativa do .NET
- **DotNetEnv**: para guardar senhas de banco entre outros

### Justificativa
- O **PostgreSQL** foi escolhido por ser uma solução de banco de dados open-source, confiável e escalável, e por ser um serviço gratis de banco online com o AIVEN.
- O uso de **Entity Framework** simplifica o mapeamento objeto-relacional (ORM), tornando o desenvolvimento mais eficiente.

---

## Configuração do Projeto
### Pré-requisitos
- .NET 6 SDK instalado ou superior
- PostgreSQL instalado e configurado

### Configuração do Banco de Dados
1. Configure a **connection string** no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "ApiDatabase": "Host=localhost;Database=seuDB;Username=seu_usuario;Password=sua_senha"
   }

## Endpoints da API

A API foi estruturada com os seguintes endpoints principais:

### Tutor

- `GET /Tutor`  
  Retorna todos os Tutores.  
- `GET /Tutor/{id}`  
  Retorna um Tutor específico.  
- `POST /Tutor`  
  Cria um novo Tutor.  
- `PUT /Tutor/{id}`  
  Atualiza um Tutor existente.  
- `DELETE /Tutor/{id}`  
  Exclui um Tutor.  

---

### Animal

- `GET /Animal`  
  Retorna todos os pets.  
- `GET /Animal/{id}`  
  Retorna um pet específico.  
- `POST /Animal`  
  Cria um novo pet.  
- `PUT /Animal/{id}`  
  Atualiza um pet existente.  
- `DELETE /Animal/{id}`  
  Exclui um pet.  

---

### Serviços

- `GET /Servico`  
  Retorna todos os serviços cadastrados.  

---

### Agendamentos

- `GET /Agendamento`  
  Retorna todos os agendamentos.  
- `GET /Agendamento/{id}`  
  Retorna um agendamento específico.  
- `POST /Agendamento`  
  Cria um novo agendamento.  
- `PUT /Agendamento/{id}`  
  Atualiza um agendamento existente.  
- `DELETE /Agendamento/{id}`  
  Exclui um agendamento.  



### Exemplo de Endpoint (TutorController)
  ```c#
 namespace AgendamentoBanhoETosa.Controller
{
    [ApiController] //controlador de API
    [Route("[controller]")] // Define a rota base como "/Tutor"
    public class TutorController : ControllerBase
    {
        private readonly ITutorServ _tutorService;
        public TutorController(ITutorServ clienteService)
        {
            _tutorService = clienteService;
        }

        // GET: /Tutor (todos os clientes)
        [HttpGet]
        public async Task<IActionResult> GetAllTutores()
        {
            // Chama o serviço para buscar os clientes
            var clientes = await _tutorService.GetAllTutoresAsync();

            // Retorna os clientes no formato JSON
            return Ok(clientes);
        }

        // GET: /Tutor/{id} (clientes por id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutorById(int id)
        {
            var cliente = await _tutorService.GetTutorByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado." });
            }
            return Ok(cliente);
        }

        // POST: /Tutor
        [HttpPost]
        public async Task<IActionResult> AddTutor([FromBody] TutorDTO novoTutor)
        {
            await _tutorService.AddTutorAsync(novoTutor);
            return CreatedAtAction(nameof(GetTutorById), new { id = novoTutor }, novoTutor);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _tutorService.GetTutorByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado para exclusão." });
            }

            await _tutorService.DeleteTutorAsync(id);
            return NoContent();
        }


    }
}
```
### Diagrama de Classes

![UAUDOG](https://github.com/user-attachments/assets/534e129a-d647-4860-be1f-2a7a6a107dde)


# Licença
> Este projeto é licenciado sob a MIT License. Consulte o arquivo LICENSE para mais informações.

