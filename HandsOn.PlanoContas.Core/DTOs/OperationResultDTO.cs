using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.DTOs
{
    public class OperationResultDTO
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public OperationResultDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
