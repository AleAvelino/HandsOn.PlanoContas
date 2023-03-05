using HandsOn.PlanoContas.Core.Enums;
using HandsOn.PlanoContas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.DTOs
{
    public class ChartAccountDTO : IBaseDomain
    {

        public string ContaPai { get; set; }

        [Required]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string AceitaLancamento { get; set; }

        [Required]
        public string Tipo { get; set; }

        public ChartAccountDTO(string contaPai, string codigo, string nome, string aceitaLancamento, string tipo)
        {
            ContaPai = contaPai;
            Codigo = codigo;
            Nome = nome;
            AceitaLancamento = aceitaLancamento;
            Tipo = tipo;
        }

    }
}