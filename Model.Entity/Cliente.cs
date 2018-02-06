using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public long IdCliente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        public int Estado { get; set; }     

        public Cliente()
        {

        }

        public Cliente(long idCliente)
        {
            this.IdCliente = idCliente;
        }

        public Cliente(long idCliente, string nome, string endereco, string telefone, string cpf)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;            
            this.CPF = cpf;
        }
    }
}
