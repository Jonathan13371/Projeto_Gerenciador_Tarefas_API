using API_Gerenciador_de_tarefas.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Gerenciador_de_tarefas.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString())) 
            {
                return ValidationResult.Success;
            }


            var primeiraLetra = value.ToString()?[0].ToString();
             if(primeiraLetra != primeiraLetra?.ToUpper()) 
            {
                return new ValidationResult("A primeira letra do nome da tarefa deve ser maiúscula");
            }

            return ValidationResult.Success;
        }
    }

}
