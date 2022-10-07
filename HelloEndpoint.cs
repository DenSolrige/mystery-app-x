public class HelloEndpoint : EndpointWithoutRequest<String>
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync("Hello World!");
    }
}