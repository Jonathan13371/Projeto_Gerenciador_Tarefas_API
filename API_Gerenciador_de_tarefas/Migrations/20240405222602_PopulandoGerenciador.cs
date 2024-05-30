using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Gerenciador_de_tarefas.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoGerenciador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into gerenciador(NomeTarefa,StatusId) " + "values('Jogar o lixo fora',1)");
            mb.Sql("Insert into gerenciador(NomeTarefa,StatusId) " + "values('Assistir One Pience',2)");

            mb.Sql("Insert into gerenciador(NomeTarefa,StatusId) " + "values('Estudar Python',2)");
            mb.Sql("Insert into gerenciador(NomeTarefa,StatusId) " + "values('Fazer exercio',3)");

            mb.Sql("Insert into gerenciador(NomeTarefa,StatusId) " + "values('Ligar para mãe',1)");
            mb.Sql("Insert into gerenciador(NomeTarefa,StatusId) " + "values('Lavar o banheiro',3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from gerenciador");
        }
    }
}
