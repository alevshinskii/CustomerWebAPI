using CustomerManagementEF.Entities;
using CustomerWebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Test;

public class NoteControllerTest
{
    private readonly ControllerTestFixture _fixture = new ();

        [Fact]
        public void ShouldBeAbleToCreateNoteController()
        {
            var controller = new NoteController(_fixture.GetNoteService());

            controller.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToGetAllNotes()
        {
            var controller = _fixture.GetNoteController();

            var result = controller.GetAll();

            var response = result as OkObjectResult;

            response.Should().NotBeNull();
            response!.Value.Should().BeOfType<List<Note>>();
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            var customer = _fixture.CreateCustomer();
            var controller = _fixture.GetNoteController();
            var result = controller.Create(customer.Notes[0]);

            var response = result as OkObjectResult;
            response.Should().NotBeNull();
            response!.Value.Should().BeOfType<Note>();
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {

            var controller = _fixture.GetNoteController();
            var customer = _fixture.CreateCustomer();
            var note = customer.Notes[0];

            var creationResult=controller.Create(note) as OkObjectResult;
            var createdNote = creationResult.Value as Note;
            controller.Get(note.Id).Should().BeAssignableTo<OkObjectResult>();

            controller.Delete(note.Id);
            controller.Get(note.Id).Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            var controller = _fixture.GetNoteController();
            var customer = _fixture.CreateCustomer();
            var note = customer.Notes[0];

            var creationResult=controller.Create(note) as OkObjectResult;
            var createdNote = creationResult.Value as Note;
            controller.Get(createdNote.Id).Should().BeAssignableTo<OkObjectResult>();

            createdNote.Text = "New Text";

            controller.Update(createdNote).Should().BeAssignableTo<OkObjectResult>();
            
            var updateResult = controller.Get(createdNote.Id) as OkObjectResult;
            var updatedNote = updateResult.Value as Note;
            updatedNote.Text.Should().BeEquivalentTo(createdNote.Text);
        }

        [Fact]
        public void ShouldCreateNoteReturnNoContentIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetAltNoteController();
            var note = customer.Notes[0];

            var result = controller.Create(note);

            result.Should().BeAssignableTo<NoContentResult>();
        }

    
        [Fact]
        public void ShouldGetNoteReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetAltNoteController();
            var note = customer.Notes[0];

            var result = controller.Get(note.Id);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void ShouldGetAllNotesReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetAltNoteController();

            var result = controller.GetAll();

            result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public void ShouldDeleteNoteReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetAltNoteController();
            var note = customer.Notes[0];

            var result = controller.Delete(note.Id);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void ShouldUpdateNoteReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetAltNoteController();
            var note = customer.Notes[0];

            var result = controller.Update(note);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void ShouldGetNoteActionReturnBadRequestIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var note= customer.Notes[0];
            var controller = _fixture.GetBrokenNoteController();

            var result = controller.Get(note.Id);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldCreateNoteActionReturnBadRequestIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var note= customer.Notes[0];
            var controller = _fixture.GetBrokenNoteController();

            var result = controller.Create(note);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldGetAllNotesActionReturnBadRequestIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var note= customer.Notes[0];
            var controller = _fixture.GetBrokenNoteController();

            var result = controller.GetAll();

            result.Should().BeAssignableTo<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldUpdateNoteActionReturnBadRequestIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var note= customer.Notes[0];
            var controller = _fixture.GetBrokenNoteController();

            var result = controller.Update(note);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldDeleteNoteActionReturnBadRequestIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var note= customer.Notes[0];
            var controller = _fixture.GetBrokenNoteController();

            var result = controller.Delete(note.Id);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
        }
}