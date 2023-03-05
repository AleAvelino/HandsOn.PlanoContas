using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Infrastructure.Auth.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly ClientsFakeList clients;

    public AuthorizationService()
    {
        clients = new(); 
    }

    public Client? GetAuthorize(string key)
    {
        return clients.GetClient(key);
    }
}
