using System.Net;
using System.Text;
using Azure;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HospitalModuleUser.ApiTests.AccountAppi
{
    public class AccountApiTest
    {
        [Fact]
        public async Task register_user_success()
        {
            //Arrange
            await using var webApp = new ApiApp();
            var command = new AccountUserDataBuilder().WithEmail("emailtest@test4.com").BuildCommand();
            

            var client = webApp.CreateClient();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
           

            //Act

            var response = await client.PostAsync("/api/Account/Register", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<AccountUserDto>(responseString);

            //Assert

            Assert.False(deserializeResponse.id.IsNullOrEmpty());
            Assert.Equal(command.email, deserializeResponse.UserName);
            Assert.Equal(command.fullName, deserializeResponse.FullName);
            Assert.Equal(command.age, deserializeResponse.Age);
            Assert.Equal(command.email, deserializeResponse.Email);
            Assert.Equal(command.PhoneNumber, deserializeResponse.PhoneNumber);
            Assert.Equal(command.address, deserializeResponse.Address);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);




        }

        [Fact]
        public async Task register_user_fail_already_email()
        {
            //Arrange
            await using var webApp = new ApiApp();
            var command = new AccountUserDataBuilder().WithEmail("emailtest@test5.com").BuildCommand();
       

            var client = webApp.CreateClient();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
      

            //Act

            var response = await client.PostAsync("/api/Account/Register", content);
            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);

            var responseSecondRegister = await client.PostAsync("/api/Account/Register", content);
            var responseString = await responseSecondRegister.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ErrorMessageResponse>(responseString);

            string expectativeErrorMessage = $"No se pudo hacer el registro: Username '{command.email}' is already taken.";

            //Assert
            Assert.False(responseSecondRegister.IsSuccessStatusCode);
            Assert.Equal(expectativeErrorMessage, deserializeResponse.ErrorMessage);
            Assert.Equal(HttpStatusCode.BadRequest, responseSecondRegister.StatusCode);
        }

        [Fact]
        public async Task register_user_fail_invalid_characters_password()
        {
            //Arrange
            await using var webApp = new ApiApp();
            var command = new AccountUserDataBuilder().WithEmail("emailtest@test6.com").WithPassword("pass").WithConfirmPassword("pass").BuildCommand();
          

            var client = webApp.CreateClient();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            //Act

            var response = await client.PostAsync("/api/Account/Register", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ErrorMessageResponse>(responseString);

            string expectativeErrorMessage = "No se pudo hacer el registro: Passwords must be at least 6 characters.";

            //Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(expectativeErrorMessage, deserializeResponse.ErrorMessage);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task register_user_fail_non_alphanumeric_charact_password()
        {
            //Arrange
            await using var webApp = new ApiApp();
            var command = new AccountUserDataBuilder().WithEmail("emailtest@test7.com").WithPassword("pass123").WithConfirmPassword("pass123").BuildCommand();

            var client = webApp.CreateClient();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            //Act

            var response = await client.PostAsync("/api/Account/Register", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ErrorMessageResponse>(responseString);

            string expectativeErrorMessage = "No se pudo hacer el registro: Passwords must have at least one non alphanumeric character.";

            //Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(expectativeErrorMessage, deserializeResponse.ErrorMessage);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task register_user_fail_non_one_digit_charact_password()
        {
            //Arrange
            await using var webApp = new ApiApp();
            var command = new AccountUserDataBuilder().WithEmail("emailtest@test7.com").WithPassword("pass*/").WithConfirmPassword("pass*/").BuildCommand();

            var client = webApp.CreateClient();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            //Act

            var response = await client.PostAsync("/api/Account/Register", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ErrorMessageResponse>(responseString);

            string expectativeErrorMessage = "No se pudo hacer el registro: Passwords must have at least one digit ('0'-'9').";

            //Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(expectativeErrorMessage, deserializeResponse.ErrorMessage);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task login_authorized_test()
        {
            //Arrange

            await using var webApp = new ApiApp();
            var usingAccountRespository = new UsingAccountRespository();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var user = new AccountUserDataBuilder().WithEmail("emailtest@test1.com").WithUserName("emailtest@test1.com").Build();
            var userRegisterResult = await usingAccountRespository.RegisterAcountUser(user, "Colombia2025*", scope);
            var roles = await usingAccountRespository.AssignRoleAccountUser("Usuario",userRegisterResult.Id,scope);

            var loginData = new
            {
                userName = "emailtest@test1.com",
                password = "Colombia2025*"
            };

            var client = webApp.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");


            //Act
            var response = await client.PostAsync("/api/Account/Login", content);
            response.EnsureSuccessStatusCode();

            var responseReadString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ResponseAccessDto>(responseReadString);


            //Assert
            Assert.NotNull(deserializeResponse);
            Assert.Equal(userRegisterResult.Id, deserializeResponse.UserDto.id);
            Assert.Equal(userRegisterResult.UserName, deserializeResponse.UserDto.UserName);
            Assert.Equal(userRegisterResult.FullName, deserializeResponse.UserDto.FullName);
            Assert.Equal(userRegisterResult.Age, deserializeResponse.UserDto.Age);
            Assert.Equal(userRegisterResult.Email, deserializeResponse.UserDto.Email);
            Assert.Equal(userRegisterResult.PhoneNumber, deserializeResponse.UserDto.PhoneNumber);
            Assert.Equal(userRegisterResult.Address, deserializeResponse.UserDto.Address);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(roles.SequenceEqual(deserializeResponse.UserDto.roles));

        }

        [Fact]
        public async Task login_no_authorized_test()
        {
            //Arrange

            await using var webApp = new ApiApp();
            var usingAccountRespository = new UsingAccountRespository();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var user = new AccountUserDataBuilder().WithEmail("emailtest@test3.com").WithUserName("emailtest@test3.com").Build();
            var userRegisterResult = await usingAccountRespository.RegisterAcountUser(user, "Colombia2025*", scope);
            var roles = await usingAccountRespository.AssignRoleAccountUser("Usuario", userRegisterResult.Id, scope);

            var loginData = new
            {
                userName = "emailtest@testfail.com",
                password = "Colombia2025*"
            };

            var client = webApp.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");


            //Act
            var response = await client.PostAsync("/api/Account/Login", content);
            var responseReadString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ErrorMessageResponse>(responseReadString);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("Clave o usuario inválido", deserializeResponse.ErrorMessage);

        }

        [Fact]
        public async Task return_bearer_token()
        {
            //Arrange

            await using var webApp = new ApiApp();
            var usingAccountRespository = new UsingAccountRespository();
            var serviceCollection = webApp.GetServiceCollection();
            using var scope = serviceCollection.CreateScope();

            var user = new AccountUserDataBuilder().WithEmail("emailtest@test2.com").WithUserName("emailtest@test2.com").Build();
            var userRegisterResult = await usingAccountRespository.RegisterAcountUser(user, "Colombia2025*", scope);
            var roles = await usingAccountRespository.AssignRoleAccountUser("Usuario", userRegisterResult.Id, scope);

            var loginData = new
            {
                userName = "emailtest@test2.com",
                password = "Colombia2025*"
            };

            var client = webApp.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");


            //Act
            var response = await client.PostAsync("/api/Account/Login", content);
            response.EnsureSuccessStatusCode();

            var responseReadString = await response.Content.ReadAsStringAsync();
            var deserializeResponse = JsonConvert.DeserializeObject<ResponseAccessDto>(responseReadString);

            //Assert
            Assert.False(string.IsNullOrEmpty(deserializeResponse.token));
        }

        private class ErrorMessageResponse
        {
            public string ErrorMessage { get; set; }
        }
    }

}
