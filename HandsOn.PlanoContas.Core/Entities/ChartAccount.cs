﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HandsOn.PlanoContas.Core.Enums;
using HandsOn.PlanoContas.Core.Interfaces;

namespace HandsOn.PlanoContas.Core.Entities
{
    [Table("ChartAccounts")]
    public class ChartAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool AcceptInclusion { get; set; }

        [Required]
        public EPlanType Type { get; set; }

        [Required]
        public int ClientId { get; set; }

        public string FatherAccount { get; set; }

        public ChartAccount(int id, string code, string name, bool acceptInclusion, EPlanType type, string father, int clientId)
        {
            Id = id;
            Code = code;
            Name = name;
            AcceptInclusion = acceptInclusion;
            Type = type;
            FatherAccount = father ?? code;
            ClientId = clientId;
        }
        public ChartAccount(int id, string code, string name, int type, string acceptInclusion, string father,int clientId = 0)
        {
            Id = id;
            Code = code.Trim();
            Name = name.Trim();
            AcceptInclusion = (acceptInclusion.Trim() == "Sim");
            Type = (EPlanType)type;
            FatherAccount = father.Trim() ?? code.Trim();
            ClientId = clientId;
        }

    }
}
