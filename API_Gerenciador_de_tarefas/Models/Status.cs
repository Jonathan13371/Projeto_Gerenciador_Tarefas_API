using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace API_Gerenciador_de_tarefas.Models
{
    public class Status
    {
        public Status()
        {
            Gerenciador = new Collection<Gerenciador>();
        }
       
        [Key]
        public int StatusId { get; set; }
        [Required]
        [StringLength(50)]
        public string? StatusTarefa { get; set; }

        public ICollection<Gerenciador>? Gerenciador{ get; set; }
    }
}
