using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Infrastructure.Auth.Authorization;

internal class ClientsFakeList
{
    private readonly List<Client> _clients = new();
    public ClientsFakeList()
    {
        _clients = new List<Client>()
        {
            new Client() { Id = 0, Name = "SystemAccount", Key = "995C5084-CC91-4005-BFC5-EBBC1060DF9C"},
            new Client() { Id = 1, Name = "Primeiro Cliente", Key = "47003A42-DA8E-4FB8-8E8A-24B356A2B0B5"},
        };
    }

    public Client? GetClient(string key)
    {
        return _clients.FirstOrDefault(c => c.Key == key);
    }





}
