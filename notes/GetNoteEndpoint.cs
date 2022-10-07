public class GetNoteEndpoint : EndpointWithoutRequest<List<Note>>
{
    public override void Configure()
    {
        Get("/notes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(NoteList.Notes);
    }
}