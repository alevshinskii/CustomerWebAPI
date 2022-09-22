namespace CustomerManagementEF.Test.Services;

public class NoteServiceTest
{
    private readonly ServiceTestFixture _fixture = new();

    [Fact]
    public void ShouldBeAbleToCreateService()
    {
        var service = new CustomerManagementEF.Services.NoteService();
        Assert.NotNull(service);
    }

    [Fact]
    public void ShouldBeAbleToGetNote()
    {
        var note= _fixture.GetNote();
        var service = _fixture.GetNoteService();
        var createdNote = service.Get(note.Id);

        Assert.NotNull(createdNote);
    }

    [Fact]
    public void ShouldBeAbleToCreateNote()
    {
        var note= _fixture.GetNote();
        var service = _fixture.GetNoteService();
        var createdNote = service.Create(note);

        Assert.NotNull(createdNote);
    }

    [Fact]
    public void ShouldBeAbleToUpdateNote()
    {
        var note = _fixture.GetNote();
        var service = _fixture.GetNoteService();

        Assert.True(service.Update(note));
    }

    [Fact]
    public void ShouldBeAbleToDeleteNote()
    {
        var note = _fixture.GetNote();
        var service = _fixture.GetNoteService();

        Assert.True(service.Delete(note.Id));
    }

    [Fact]
    public void ShouldBeAbleToGetAllNotes()
    {
        var service = _fixture.GetNoteService();

        Assert.NotEmpty(service.GetAll());
    }
}