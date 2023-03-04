using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.DTOs
{
    public class NextCodeRequestDTO
    {
        public string Code { get; set; }
        public NextCodeRequestDTO() { Code = string.Empty; }
        public NextCodeRequestDTO(string code) { Code = code; }
    }
}
