public class PostDocumentEndpoint : Endpoint<Document,DocumentId>
{
    public override void Configure()
    {
        Post("/documents");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Document document, CancellationToken ct)
    {
        String UUID = Guid.NewGuid().ToString();
        await File.WriteAllTextAsync($"{UUID}.txt", document.Content);
        await SendAsync(new DocumentId(){DocId = UUID});
    }
}