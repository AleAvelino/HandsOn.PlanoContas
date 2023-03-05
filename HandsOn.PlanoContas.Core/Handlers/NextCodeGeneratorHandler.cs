using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Handlers
{
    public class NextCodeGeneratorHandler
    {

        private readonly List<ChartAccount> _items;

        public NextCodeGeneratorHandler(IEnumerable<ChartAccount> items)
        {
            _items = new(items);
        }


        /*
        ● Para o cenário em que o usuário está criando uma conta filha da conta 
            “2.2”, a API deve sugerir o código “2.2.8” se a maior filha já cadastrada 
            for a “2.2.7”. (Sempre use a lógica do maior + 1);

        ● O maior código possível é “999” independente do nível que você está. 
            Então o código “1.2.999” é um código válido e “1.2.1000” não;

        ● Se a conta “1.2.999” já existe e a API foi chamada para sugerir o 
            próximo código para o pai “1.2”ela deve: 
            ○ Retornar que o pai agora deve ser o “1”;
            ○ Retornar o código do próximo filho deste novo pai.

        ● Se atente para criar uma lógica que consiga sugerir o novo pai "9" com 
            o próximo filho "9.11" caso você tente buscar um código para o pai 
            “9.9.999.999” em um plano de contas que já tenha os seguintes 
            registros:
                ...
                9.9.999.999.998 Conta X
                9.9.999.999.999 Conta Y
                9.10 Conta Z

        */
        public NextCodeResponseDTO Generate(string parent)
        {
            NextCodeResponseDTO response = new(parent, "");
            string step1 = NextCodePlus(parent);
            var step2 = IsValidMaxCode(step1);
            if (step2 && !CodeExists(step1))
            {
                response.NextCode = step1;
            }
            else
            {
                string step3 = HasToUpgradeLevel(parent);
                response = Generate(step3);
            }
            return response;
        }


        private List<ChartAccount> GetItemsbyParent(string parent)
        {
            return _items
                .Where(x => x.ParentAccount == parent)
                .ToList();
        }
        private bool CodeExists(string code)
        {
            return _items.Any(x => x.Code == code);
        }



        private static int[] GetLevelsParseInt(string code)
        {
            var strLevels = code.Split('.');
            int[] intLevels = new int[strLevels.Length];
            for (int i = 0; i < strLevels.Length; i++)
                intLevels[i] = int.Parse(strLevels[i]);
            return intLevels;
        }
        private static int GetLastLevelInteger(string code)
        {
            int[] levels = GetLevelsParseInt(code);
            return levels[^1];
        }


        /*

        

        ● Se a conta “1.2.999” já existe e a API foi chamada para sugerir o 
            próximo código para o pai “1.2”ela deve: 
            ○ Retornar que o pai agora deve ser o “1”;
            ○ Retornar o código do próximo filho deste novo pai.

        ● Se atente para criar uma lógica que consiga sugerir o novo pai "9" com 
            o próximo filho "9.11" caso você tente buscar um código para o pai 
            “9.9.999.999” em um plano de contas que já tenha os seguintes 
            registros:
                ...
                9.9.999.999.998 Conta X
                9.9.999.999.999 Conta Y
                9.10 Conta Z


        */

        /* ● Para o cenário em que o usuário está criando uma conta filha da conta 
            “2.2”, a API deve sugerir o código “2.2.8” se a maior filha já cadastrada 
            for a “2.2.7”. (Sempre use a lógica do maior + 1);
         */
        public string NextCodePlus(string code)
        {
            int last = GetLastLevelInteger(code);
            int next = last++;
            return next.ToString();
        }


        /* ● O maior código possível é “999” independente do nível que você está. 
            Então o código “1.2.999” é um código válido e “1.2.1000” não; 
         */
        private const int MAX_VALUE = 999;
        public bool IsValidMaxCode(string code)
        {
            int last = GetLastLevelInteger(code);
            return last <= MAX_VALUE;
        }

        /* 
         
         */
        public string HasToUpgradeLevel(string code)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is a recursive routine to suggest the next valid code
        /// In cases where code already exists or maxes out, this routine needs to find the next available higher level.
        /// </summary>
        /// <param name="parent">Parent level </param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string IsNeededToUpLevel(string parent, string code)
        {
            /*
             * O codigo não será valido
             * Verificar os niveis do pai
             * tentar subir para o proximo
             * se ja tiver, sugerir o próximo nivel mais alto
             */
            string suggested = code;
            List<ChartAccount> lst;
            if (IsValidMaxCode(code) && !CodeExists(code))
            {
                lst = GetItemsbyParent(parent);

                return code;

            }
            else
            {
                var levels = GetLevelsParseInt(code);
                int last = levels[^1];
                for (int i = levels.Length; i > 0; i--)
                {

                }

            }



            return suggested;
        }





    }
}
