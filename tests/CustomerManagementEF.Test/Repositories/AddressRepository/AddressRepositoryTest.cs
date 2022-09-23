using CustomerManagementEF.Entities;

namespace CustomerManagementEF.Test.Repositories.AddressRepository
{
    public class AddressRepositoryTest
    {
        private readonly AddressRepositoryFixture _fixture = new ();

        [Fact]
        public void ShouldBeAbleToCreateAddressRepo()
        {
            var repository = new CustomerManagementEF.Repositories.AddressRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetAddressRepository();
            Address address = _fixture.GetAddress();

            var createdAddress = repository.Create(address);

            Assert.NotNull(createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetAddressRepository();
            Address address = _fixture.GetAddress();

            var createdAddress = repository.Create(address);

            var readedAddress = repository.Read(createdAddress!.AddressId);

            Assert.Equal(createdAddress.AddressId, readedAddress!.AddressId);
            Assert.Equal(createdAddress.AddressLine, readedAddress.AddressLine);
            Assert.Equal(createdAddress.AddressLine2, readedAddress.AddressLine2);
            Assert.Equal(createdAddress.AddressType, readedAddress.AddressType);
            Assert.Equal(createdAddress.CustomerId, readedAddress.CustomerId);
            Assert.Equal(createdAddress.City, readedAddress.City);
            Assert.Equal(createdAddress.Country, readedAddress.Country);
            Assert.Equal(createdAddress.PostalCode, readedAddress.PostalCode);
            Assert.Equal(createdAddress.State, readedAddress.State);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetAddressRepository();
            Address address = _fixture.GetAddress();

            var createdAddress = repository.Create(address);

            var oldAddress = address.AddressLine;
            var newAddress="New Address Line";

            createdAddress!.AddressLine = newAddress;

            repository.Update(createdAddress);

            var updatedAddress = repository.Read(createdAddress.AddressId);

            Assert.NotEqual(oldAddress, updatedAddress!.AddressLine);
            Assert.Equal(newAddress, updatedAddress.AddressLine);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetAddressRepository();
            Address address = _fixture.GetAddress();

            var createdAddress = repository.Create(address);

            repository.Delete(createdAddress!.AddressId);

            var readedAddress = repository.Read(createdAddress.AddressId);

            Assert.Null(readedAddress);
        }

        [Fact]
        public void ShouldBeAbleToReadAllAddressesById()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetAddressRepository();
            Address address = _fixture.GetAddress();

            repository.Create(address);
            repository.Create(address);

            var addresses = repository.ReadAll(address.CustomerId);

            Assert.NotEmpty(addresses);
            Assert.Equal(2,addresses.Count);
        }


        [Fact]
        public void ShouldBeAbleToReadAllAddresses()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetAddressRepository();
            Address address = _fixture.GetAddress();

            repository.Create(address);
            repository.Create(address);

            var addresses = repository.ReadAll();

            Assert.NotEmpty(addresses);
            Assert.Equal(2,addresses.Count);
        }

    }
}
