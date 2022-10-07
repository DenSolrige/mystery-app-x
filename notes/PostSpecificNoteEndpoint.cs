public class PostSpecificNoteEndpoint : Endpoint<SpecificNote,SpecificNote>
{
    public override void Configure()
    {
        Post("/notes/{Index}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SpecificNote note, CancellationToken ct)
    {
        NoteList.Notes.Insert(note.Index,new Note(){Content = note.Content});
        await SendAsync(note);
    }
}