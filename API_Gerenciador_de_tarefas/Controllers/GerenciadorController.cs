using API_Gerenciador_de_tarefas.Context;
using API_Gerenciador_de_tarefas.Models;
using API_Gerenciador_de_tarefas.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Gerenciador_de_tarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GerenciadorController : ControllerBase
    {

        private readonly AppDbContext _context;

        public GerenciadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListaDeTarefas")]
        public async Task<ActionResult<IEnumerable<Gerenciador>>> ListaDeTarefas()
        {
            try
            {
                var listaTarefas = await _context.Gerenciador!.AsTracking().ToListAsync();


                if (listaTarefas is null)
                { return NotFound(); }
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("pesquisar-por-nome/{NomeTarefa}")]
        [PrimeiraLetraMaiuscula]
        public async Task<ActionResult<Gerenciador>> PesquisarTarefaNome(string NomeTarefa)
        {
            var pesquisarNomDTO = await _context.Gerenciador!.FirstOrDefaultAsync(p => p.NomeTarefa == NomeTarefa);

            if (pesquisarNomDTO is null)
            {
                return NotFound("Nome da Tarefa Inválido, certifique-se que não há Espaços sobrando");
            }
            return Ok(pesquisarNomDTO);
        }


        [HttpPost("AdicionarTarefa")]
        [PrimeiraLetraMaiuscula]
        public ActionResult AdicionarTarefa(Gerenciador gerenciador)
        {
            try
            {
                var tarefasComMesmoNome = _context.Gerenciador!.Count(t => t.NomeTarefa == gerenciador.NomeTarefa);
                if (tarefasComMesmoNome > 0)
                {
                    return Conflict("Já existe uma tarefa com o mesmo nome. Por favor, insira outro nome.");
                }
                var IdExistente = _context.Gerenciador!.FirstOrDefault(t => t.GerenciadorId == gerenciador.GerenciadorId);
                if (gerenciador.GerenciadorId == gerenciador.GerenciadorId)
                {
                    _context.Gerenciador!.Add(gerenciador);
                    _context.SaveChanges();

                    return Ok(gerenciador);
                }
                else
                {
                    return NotFound("O Id dessa tarefa já existe ou O Id informado é inválido");
                }

            }
            catch (Exception ex)
            { 
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut("AlterarTarefa/{id:int}")]
        [PrimeiraLetraMaiuscula]
        public IActionResult AlterarPorId(int id, Gerenciador gerenciadorDTO)
        {
            try
            {
                if (id != gerenciadorDTO.GerenciadorId)
                {
                    return BadRequest("Id inválido, todos os campos id são obrigatórioss");
                }

                var statusExistente = _context.Status!.FirstOrDefault(s => s.StatusId == gerenciadorDTO.StatusId);

                if (statusExistente == null)
                {
                    return BadRequest("Status inválido");
                }



                _context.Gerenciador!.Entry(gerenciadorDTO).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(gerenciadorDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }

        [HttpDelete("ExcluirTarefa/int:id")]

        public ActionResult<Gerenciador> Delete(int id)
        {
            try
            {
                var deleteTarefaDTO = _context.Gerenciador!.FirstOrDefault(d => d.GerenciadorId == id);
                if (deleteTarefaDTO is null)
                {
                    return NotFound("Tarefa não encontrada...");
                }
                _context.Remove(deleteTarefaDTO);
                _context.SaveChanges();
                return Ok("Removido com sucesso ");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }



        }
    }
}
