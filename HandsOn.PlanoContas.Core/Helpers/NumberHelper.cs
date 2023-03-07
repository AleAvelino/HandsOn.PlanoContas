using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.Helpers
{
    public static class Numbers
    {

        public static string AddZeros(string text, int qtd)
        {
            string ret = text;
            for (int i = 0; i < qtd; i++)
            {
                if (ret.Length >= qtd) return ret;
                ret = string.Concat("0", ret);
            }
            return ret;
        }

        public static string ComputeCode(string code)
        {
            string[] levels = code.Split('.');
            for (int i = 0; i < levels.Length; i++)
                levels[i] = AddZeros(levels[i],3);

            return String.Join('.',levels).Replace(".","");
        }

        public static bool IsNumeric(string value) => value.All(char.IsNumber);


    }
}
