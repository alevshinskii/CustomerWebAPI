using CustomerManagementEF.Entities;
using CustomerManagementEF.Test.Repositories.CustomerRepository;

namespace CustomerManagementEF.Test.Repositories.NoteRepository
{
    public class NoteRepositoryFixture
    {
        private readonly CustomerRepositoryFixture _customerFixture = new CustomerRepositoryFixture();

        public void ClearDb()
        {
            _customerFixture.ClearDb();
        }

        public Note GetNote()
        {
            var customerRepository = _customerFixture.GetCustomerRepository();
            var customer = customerRepository.Create(_customerFixture.GetCustomer());

            return new Note()
            {
                Id = 1,
                CustomerId = customer!.Id,
                Text = "Some text"
            };
        }

        public NoteTestRepository GetNoteRepository()
        {
            return new NoteTestRepository();
        }

        public NoteTestRepository GetBrokenNoteRepository()
        {
            var noteRepository = GetNoteRepository();
            noteRepository.Context = null;
            return noteRepository;
        }
    }
}

