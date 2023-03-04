using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.DTOs
{
    public  class NextCodeResponseDTO
    {
        public string ParentCode { get; set; }
        public string NextCode { get; set; }

        public NextCodeResponseDTO(string parentCode, string nextCode)
        {
            ParentCode = parentCode;
            NextCode = nextCode;
        }
    }
}
