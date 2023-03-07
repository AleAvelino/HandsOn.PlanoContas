using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.DTOs
{
    public static class MessageDTO
    {
        public const string SEARCH_CODE_IS_NOT_NUMBER = "O código da busca deve ser um número";
        public const string SEARCH_ERROR = "Houve um erro na busca";

        public const string COMMAND_SUCCESS = "Dados Salvos com sucesso!";
        public const string COMMAND_ERROR = "Houve uma falha ao salvar os dados.";
        public const string COMMAND_GENERIC_FAIL = "O Plano não pode ser criado, Por favor verifique os dados e tente novamente";
        public const string COMMAND_ERROR_VALIDATE_CODE = "O código informado é inválido";
        public const string COMMAND_ERROR_VALIDATE_CODE_REPEAT = "O código informado já existe";
        public const string COMMAND_ERROR_VALIDATE_DELETE = "O item informado é inválido";
        public const string COMMAND_ERROR_VALIDATE_PARENT = "A conta que aceita lançamentos não pode ter contas filhas";
        public const string COMMAND_ERROR_VALIDATE_PARENT_TYPE = "O item deve possuir o mesmo tipo do Pai";
        public const string COMMAND_ERROR_VALIDATE_INVALID_OBJECT = "O item é inválido, por favor preencha todos os campos";

    }
}
