using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Autotests.TestAQA1.DTO
{
    public class Tests
    {
        private static HttpClient client = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3Hs8b7NQ3PIDlXclOtb4kOF2C9Z");             // free_user_3Hs5R7VxAD3zzrYAcdt3Anqc5bY

        }
        [Test]
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();
        }
        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();

            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet)!;
            UserDataDTO user = userResponse.Data;

            Assert.That(user.ID, Is.EqualTo(2));
        }
		[Test] //Test3 проверка обработки create
        public async Task Test3()
        {
            var request = new CreateUserRequestDTO
            {
                Name = "James",
                Job = "Intro"
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", request);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDTO createdUser = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(createdUser.Name, Is.EqualTo(request.Name));
            Assert.That(createdUser.Job, Is.EqualTo(request.Job));
        }
        
         [Test] //test4 проверить статус код после изменения (PUT) для /user2
        	public async Task Test4()
        {
            var request = new CreateUserRequestDTO
            {
                Name = "James",
                Job = "Intro"
            };

            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        
        [Test] //Test5 delete проверить статус код после выполнения 
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
