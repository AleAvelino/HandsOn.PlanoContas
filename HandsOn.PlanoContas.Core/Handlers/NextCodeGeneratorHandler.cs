using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Handlers
{
    /// <summary>
    /// Handler to Suggest the New Code 
    /// </summary>
    public class NextCodeGeneratorHandler
    {

        public List<ChartAccount> Items;

        public NextCodeGeneratorHandler()
        {
            Items = new();
        }
        public NextCodeGeneratorHandler(IEnumerable<ChartAccount> items)
        {
            Items = new(items);
        }

        /// <summary>
        /// Main Routine to Generate code
        /// </summary>
        /// <param name="parent">Parent code to suggest</param>
        /// <returns>Next code</returns>
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
                var step3 = GetHigherlevel(parent);

                response.NextCode = step3;
                response.ParentCode = CalculateParent(step3);
            }
            return response;
        }

        private ChartAccount GetItem(string code)
        {
            return Items
                .First(x => x.Code == code);
        }

        private List<ChartAccount> GetItemsbyParent(string parent)
        {
            return Items
                .Where(x => x.ParentAccount == parent)
                .ToList();
        }
        private bool CodeExists(string code)
        {
            return Items.Any(x => x.Code == code);
        }

        private string GetLastCodeByParent(string code, bool calcParent = false)
        {
            string parent = calcParent ? CalculateParent(code) : code;
            var parentsLst = GetItemsbyParent(parent);
            if (!parentsLst.Any()) return code;
            var tmp = parentsLst
                .Select(x => new { x.Code, Order = int.Parse(x.Code.Replace(".", "")) })
                .ToArray();          
            var max = tmp.Max(m => m.Order);
            return tmp.First(x => x.Order == max).Code;
        }

        private static string CalculateParent(string code)
        {
            return code.Contains('.')                
                ? code.TrimEnd('.').Remove(code.LastIndexOf('.'))
                : code;
        }



        private static int[] GetLevelsParseInt(string code)
        {
            var strLevels = code.Split('.');
            int[] intLevels = new int[strLevels.Length];
            for (int i = 0; i < strLevels.Length; i++)
                intLevels[i] = int.Parse(strLevels[i]);
            return intLevels;
        }


        public string NextCodePlus(string code, bool calcParent = false)
        {
            string max = GetLastCodeByParent(code, calcParent);
            int[] levels = GetLevelsParseInt(max);
            int last = levels[^1];
            last++;
            levels[^1] = last;
            return String.Join(".",levels);
        }


        private const int MAX_VALUE = 999;
        public static bool IsValidMaxCode(string code)
        {
            int[] levels = GetLevelsParseInt(code);
            for (int i = 0; i < levels.Length; i++)
            {
                if (levels[i] > MAX_VALUE)
                    return false;
            }
            return true;
        }

        public static int HasToUpgradeLevel(string code)
        {            
            int[] levels = GetLevelsParseInt(code);
            int resp = levels.Length-1;

            for (int i = levels.Length-1; i >= 0; i--)
            {
                if (levels[i] >= MAX_VALUE)
                    resp = (resp >= i)
                        ? (i > 0) ? i-1 : 0
                        : resp;
            }

            return resp;            
        }

        /// <summary>
        /// This is a recursive routine to suggest the next valid code, always going up one level to the highest.
        /// In cases where code already exists or maxes out, this routine needs to find the next available higher level.
        /// </summary>
        /// <param name="parent">Parent level </param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetHigherlevel(string code)
        {

            int destLevel = HasToUpgradeLevel(code);
            int[] levels = GetLevelsParseInt(code);
            string nextLevel = $"{levels[0]}";

            for (int i = 0; i < destLevel; i++)
            {
                nextLevel = string.Concat(nextLevel, ".", levels[i]);
            }
            string nextCode = NextCodePlus(nextLevel,true);  

            if (IsValidMaxCode(nextCode))
            {
                return  CodeExists(nextCode) ? NextCodePlus(GetItem(nextCode).ParentAccount, true) : nextCode;
            }
            else
            {
                string suggest = GetHigherlevel(NextCodePlus(nextCode, true));
                return suggest;
            }

        }





    }
}
