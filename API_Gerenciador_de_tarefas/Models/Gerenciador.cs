using API_Gerenciador_de_tarefas.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Gerenciador_de_tarefas.Models
{
    public class Gerenciador
    {
        [Key]
        public int GerenciadorId { get; set; }
        [Required]
        [StringLength(50)]
        [PrimeiraLetraMaiuscula]
        public String? NomeTarefa { get; set; }
        [Required]
        public int StatusId { get; set; }
        [JsonIgnore]
        public Status?Status{ get; set; }



    }
}
