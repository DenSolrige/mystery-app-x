public class GetSpecificDocumentEndpoint : Endpoint<SpecificDocument,SpecificDocument>
{
    public override void Configure()
    {
        Get("/documents/{DocId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SpecificDocument document, CancellationToken ct)
    {
        string text = System.IO.File.ReadAllText($"{document.DocId}.txt");
        document.Content = text;
        await SendAsync(document);
    }
}