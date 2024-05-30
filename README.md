 Gerenciador de Tarefas API

Esta API permite realizar operações de CRUD (Criar, Ler, Atualizar, Deletar) em um gerenciador de tarefas. Cada tarefa possui atributos como Nome da Tarefa, Status da tarefa, (pendente ou concluída).

 Funcionalidades
- **Criar Tarefa:** Adicione uma nova tarefa.
- **Listar Tarefas:** Veja todas as tarefas cadastradas.
- **Atualizar Tarefa:** Edite os detalhes de uma tarefa existente.
- **Deletar Tarefa:** Remova uma tarefa do sistema.

### Endpoints

1. **Criar uma nova tarefa**
    - `POST /AdicionarTarefa`
2. **Listar todas as tarefas**
    - `GET /ListaDeTarefas`
3. **Obter detalhes de uma tarefa específica**
    - `GET /pesquisar-por-nome/{NomeTarefa}`
4. **Atualizar uma tarefa**
    - `PUT /AlterarTarefa/{id}`
5. **Deletar uma tarefa**
    - `DELETE /ExluirTarefa/{id}`


### Tecnologias Utilizadas
- C#
- ASP.NET Core
- SQL Server

