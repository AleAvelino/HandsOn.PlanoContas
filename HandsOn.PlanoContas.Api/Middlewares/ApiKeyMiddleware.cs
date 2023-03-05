namespace HandsOn.PlanoContas.Api;

using HandsOn.PlanoContas.Infrastructure.Auth.Authorization;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string APIKEY = "XApiKey";
    private readonly IAuthorizationService authorizationService;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
        this.authorizationService = new AuthorizationService();
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(APIKEY, out
                var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided ");
            return;
        }


        Client client = authorizationService.GetAuthorize(extractedApiKey);
        if (client == null)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client");
            return;
        }
        context.Items["Client"] = client;

        await _next(context);
    }
}