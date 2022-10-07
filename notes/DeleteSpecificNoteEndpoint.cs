public class DeleteSpecificNoteEndpoint : Endpoint<SpecificNote,String>
{
    public override void Configure()
    {
        Delete("/notes/{Index}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SpecificNote note, CancellationToken ct)
    {
        NoteList.Notes.RemoveAt(note.Index);
        await SendAsync("Done");
    }
}