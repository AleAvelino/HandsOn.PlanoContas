using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Handlers;

namespace HandsOn.PlanoContas.UnitTests.Core
{
    internal class FakeDomainMockList : List<ChartAccount>
    {

        public FakeDomainMockList()
        {
            LoadList();
        }

        private void LoadList()
        {
            List<ChartAccount> list = new()
            {
                new ChartAccount(   1   ,"	1	","	Receitas	",  1   ,"	Não	"    ,"" ),
                new ChartAccount(   2   ,"	1.1	","	Taxa condominial	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   3   ,"	1.2	","	Reserva de dependência	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   4   ,"	1.3	","	Multas	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   5   ,"	1.4	","	Juros	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   6   ,"	1.5	","	Multa condominial	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   7   ,"	1.6	","	Água	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   8   ,"	1.7	","	Gás	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   9   ,"	1.8	","	Luz e energia	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   10  ,"	1.9	","	Fundo de reserva	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   11  ,"	1.10	","	Fundo de obras	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   12  ,"	1.11	","	Correção monetária	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   13  ,"	1.12	","	Transferência entre contas	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   14  ,"	1.13	","	Pagamento duplicado	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   15  ,"	1.14	","	Cobrança	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   16  ,"	1.15	","	Crédito	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   17  ,"	1.16	","	Água mineral	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   18  ,"	1.17	","	Estorno taxa de resgate	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   19  ,"	1.18	","	Acordo	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   20  ,"	1.19	","	Honorários	",  1   ,"	Sim	"    ,"1"    ),
                new ChartAccount(   21  ,"	2	","	Despesas	",  2   ,"	Não	"    ,"" ),
                new ChartAccount(   22  ,"	2.1	","	Com pessoal	",  2   ,"	Não	"    ,"2"    ),
                new ChartAccount(   23  ,"	2.1.1	","	Salário	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   24  ,"	2.1.2	","	Adiantamento salarial	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   25  ,"	2.1.3	","	Hora extra	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   26  ,"	2.1.4	","	Férias	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   27  ,"	2.1.5	","	13º salário	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   28  ,"	2.1.6	","	Adiantamento 13º salário	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   29  ,"	2.1.7	","	Adicional de função	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   30  ,"	2.1.8	","	Aviso prévio	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   31  ,"	2.1.9	","	INSS	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   32  ,"	2.1.10	","	FGTS	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   33  ,"	2.1.11	","	PIS	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   34  ,"	2.1.12	","	Vale refeição	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   35  ,"	2.1.13	","	Vale transporte	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   36  ,"	2.1.14	","	Cesta básica	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   37  ,"	2.1.15	","	Acordo trabalhista	",  2   ,"	Sim	"    ,"2.1"  ),
                new ChartAccount(   38  ,"	2.2	","	Mensais	",  2   ,"	Não	"    ,"2"    ),
                new ChartAccount(   39  ,"	2.2.1	","	Energia elétrica	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   40  ,"	2.2.2	","	Água e esgoto	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   41  ,"	2.2.3	","	Taxa de administração	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   42  ,"	2.2.4	","	Gás	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   43  ,"	2.2.5	","	Seguro obrigatório	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   44  ,"	2.2.6	","	Telefone	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   45  ,"	2.2.7	","	Softwares e aplicativos	",  2   ,"	Sim	"    ,"2.2"  ),
                new ChartAccount(   46  ,"	2.3	","	Manutenção	",  2   ,"	Não	"    ,"2"    ),
                new ChartAccount(   47  ,"	2.3.1	","	Elevador	",  2   ,"	Sim	"    ,"2.3"  ),
                new ChartAccount(   48  ,"	2.3.2	","	Limpeza e conservação	",  2   ,"	Sim	"    ,"2.3"  ),
                new ChartAccount(   49  ,"	2.3.3	","	Jardinagem	",  2   ,"	Sim	"    ,"2.3"  ),
                new ChartAccount(   50  ,"	2.4	","	Diversas	",  2   ,"	Não	"    ,"2"    ),
                new ChartAccount(   51  ,"	2.4.1	","	Honorários de advogado	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   52  ,"	2.4.2	","	Xerox	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   53  ,"	2.4.3	","	Correios	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   54  ,"	2.4.4	","	Despesas judiciais	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   55  ,"	2.4.5	","	Multas	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   56  ,"	2.4.6	","	Juros	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   57  ,"	2.4.7	","	Transferência entre contas	",  2   ,"	Sim	"    ,"2.4"  ),
                new ChartAccount(   58  ,"	3	","	Despesas bancárias	",  2   ,"	Não	"    ,"" ),
                new ChartAccount(   59  ,"	3.1	","	Registro de boletos	",  2   ,"	Sim	"    ,"3"    ),
                new ChartAccount(   60  ,"	3.2	","	Processamento de boletos	",  2   ,"	Sim	"    ,"3"    ),
                new ChartAccount(   61  ,"	3.3	","	Registro e processamento de boletos	",  2   ,"	Sim	"    ,"3"    ),
                new ChartAccount(   62  ,"	3.4	","	Resgates	",  2   ,"	Sim	"    ,"3"    ),
                new ChartAccount(   63  ,"	4	","	Outras receitas	",  1   ,"	Não	"    ,"" ),
                new ChartAccount(   64  ,"	4.1	","	Rendimento de poupança	",  1   ,"	Sim	"    ,"4"    ),
                new ChartAccount(   65  ,"	4.2	","	Rendimento de investimentos	",  1   ,"	Sim	"    ,"4"    )


            };
            this.Clear();
            this.AddRange(list);

        }

    }
}
