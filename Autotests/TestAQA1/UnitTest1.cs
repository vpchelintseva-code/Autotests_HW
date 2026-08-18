using System.Text.Json;

namespace TestAQA1
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
        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}