public class PutNoteEndpoint : Endpoint<SpecificNote,SpecificNote>
{
    public override void Configure()
    {
        Put("/notes/{Index}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SpecificNote note, CancellationToken ct)
    {
        NoteList.Notes[note.Index] = new Note(){Content = note.Content};
        await SendAsync(note);
    }
}