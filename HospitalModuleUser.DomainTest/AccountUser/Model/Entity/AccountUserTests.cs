

namespace HospitalModuleUser.DomainTest.AccountUser.Model.Entity
{
    public class AccountUserTests
    {
        [Fact]
        public void should_show_exception_fullName_null()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new AccountUserDataBuilder().WithFullName(null).Build());

            Assert.Equal("Esta propiedad no puede ser null o vacía.", exception.Message);

        }

        [Fact]
        public void should_show_exception_fullName_empty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new AccountUserDataBuilder().WithFullName("").Build());

            Assert.Equal("Esta propiedad no puede ser null o vacía.", exception.Message);

        }
    }
}
