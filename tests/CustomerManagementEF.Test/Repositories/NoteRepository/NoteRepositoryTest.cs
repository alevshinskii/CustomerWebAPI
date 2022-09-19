using CustomerManagementEF.Entities;

namespace CustomerManagementEF.Test.Repositories.NoteRepository
{

    public class NoteRepositoryTest
    {
        private readonly NoteRepositoryFixture _fixture = new NoteRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateNoteRepo()
        {
            var repository = new CustomerManagementEF.Repositories.NoteRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            var createdNote = repository.Create(note);

            Assert.NotNull(createdNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNote()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            var createdNote = repository.Create(note);

            var readedNote = repository.Read(createdNote.Id);

            Assert.Equal(createdNote.Id, readedNote.Id);
            Assert.Equal(createdNote.CustomerId, readedNote.CustomerId);
            Assert.Equal(createdNote.Text, readedNote.Text);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            var oldNote = note.Text;
            var newNote="New Text";

            var createdNote = repository.Create(note);
            createdNote!.Text = newNote;

            repository.Update(createdNote);

            var updatedNote = repository.Read(createdNote.Id);

            Assert.NotEqual(oldNote, updatedNote!.Text);
            Assert.Equal(newNote, updatedNote.Text);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            var createdNote = repository.Create(note);

            repository.Delete(createdNote.Id);

            var readedNote = repository.Read(createdNote.Id);

            Assert.Null(readedNote);
        }

        [Fact]
        public void ShouldUpdateReturnsFalseIfNoLinesAffected()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            repository.Create(note);

            note.Text = "new text";
            note.Id = 0;

            Assert.False(repository.Update(note));
        }

        [Fact]
        public void ShouldDeleteReturnsFalseIfNoLinesAffected()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            repository.Create(note);

            note.Text = "new text";

            Assert.False(repository.Delete(0));
        }

        [Fact]

        public void ShouldBeAbleToReadAllNotes()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            repository.Create(note);
            repository.Create(note);
            repository.Create(note);

            var notes = repository.ReadAll();

            Assert.NotEmpty(notes);
            Assert.Equal(3, notes.Count);
        }

        [Fact]
        public void ShouldBeAbleToReadAllNotesById()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetNoteRepository();
            Note note = _fixture.GetNote();

            repository.Create(note);
            repository.Create(note);

            var notes = repository.ReadAll(note.CustomerId);

            Assert.NotEmpty(notes);
            Assert.Equal(2,notes.Count);
        }

    }
}
