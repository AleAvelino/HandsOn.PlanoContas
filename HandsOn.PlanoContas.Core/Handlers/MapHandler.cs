using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Enums;


namespace HandsOn.PlanoContas.Core.Handlers
{
    internal static class MapHandler
    {

        internal static ChartAccountDTO GetDTO(ChartAccount chartAccount)
        {
            return new ChartAccountDTO(
                chartAccount.FatherAccount,
                chartAccount.Code,
                chartAccount.Name,
                (chartAccount.AcceptInclusion) ? "Sim" : "Não",
                GetTypeName(chartAccount.Type)
            );
        }

        internal static ChartAccount GetChartAccount(ChartAccountDTO dto)
        {
            bool accept = GetBoolByString(dto.AceitaLancamento);

            return new ChartAccount(0, 
                dto.Codigo, 
                dto.Nome, 
                accept,
                GetTypeByName(dto.Tipo), 
                dto.ContaPai);            
        }

        internal static bool GetBoolByString(string value)
        {
            var valuesTrue = new[] { "sim", "yes", "true", "s", "y", "1" };
            return valuesTrue.Any(value.ToLower().Contains);
        }


        internal static string GetTypeName(EPlanType type)
        {
            return type switch
            {
                EPlanType.Revenue => "Receita",
                EPlanType.Expense => "Despesa",
                _ => ""
            };
        }

        internal static EPlanType GetTypeByName(string name)
        {
            return name.ToLower() switch
            {
                "receita" => EPlanType.Revenue,
                "despesa" => EPlanType.Expense,
                _ => EPlanType.Unknown,
            };
        }

       

    }


}
