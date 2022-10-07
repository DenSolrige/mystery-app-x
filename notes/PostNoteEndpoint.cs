public class PostNoteEndpoint : Endpoint<Note,SpecificNote>
{
    public override void Configure()
    {
        Post("/notes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Note note, CancellationToken ct)
    {
        NoteList.Notes.Add(note);
        var response = new SpecificNote()
        {
            Index = NoteList.Notes.Count-1,
            Content = note.Content
        };

        await SendAsync(response);
    }
}