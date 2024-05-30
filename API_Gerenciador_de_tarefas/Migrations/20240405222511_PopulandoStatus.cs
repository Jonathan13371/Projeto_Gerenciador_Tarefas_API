using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Gerenciador_de_tarefas.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into status(StatusTarefa) " + "values('Pendente')");
            mb.Sql("Insert into status(StatusTarefa) " + "values('Em Progresso')");
            mb.Sql("Insert into status(StatusTarefa) " + "values('Concluído')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Status");
        }
    }
}
