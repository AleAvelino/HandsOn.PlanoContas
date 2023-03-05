
namespace HandsOn.PlanoContas.Infrastructure.Auth.Authorization;

public interface IAuthorizationService
{
    Client? GetAuthorize(string key);
}
