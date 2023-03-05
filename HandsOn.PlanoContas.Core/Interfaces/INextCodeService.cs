using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.DTOs;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface INextCodeService
    {
        Task<NextCodeResponseDTO> GetNextCode(int clientId, string parentCode);
    }
}
