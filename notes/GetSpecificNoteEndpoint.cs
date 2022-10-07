public class GetSpecificNoteEndpoint : Endpoint<SpecificNote,SpecificNote>
{
    public override void Configure()
    {
        Get("/notes/{Index}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SpecificNote note, CancellationToken ct)
    {
        note.Content = NoteList.Notes.ElementAt(note.Index).Content;
        await SendAsync(note);
    }
}