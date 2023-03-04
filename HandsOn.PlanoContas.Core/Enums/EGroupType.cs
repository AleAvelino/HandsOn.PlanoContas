using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace HandsOn.PlanoContas.Core.Enums
{
    public enum EPlanType
    {
        [Display(Name = "Desconhecido")]
        Unknown = 0,
        [Display(Name = "Receita")]
        Revenue = 1,
        [Display(Name = "Despesa")]
        Expense = 2
    }
}
