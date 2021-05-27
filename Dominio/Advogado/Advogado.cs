using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Advogado
{
    public class Advogado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatorio informar o Nome do Advogado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatorio informar a Senioridade do Advogado")]
        public string Senioridade { get; set; }

        [Required(ErrorMessage = "É obrigatorio informar o endereço do Advogado")]
        public string Endereco { get; set; }
    }
}
