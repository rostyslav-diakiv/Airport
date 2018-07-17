namespace Airport.WebApi.Tests.IntergationTests
{
    using System.Threading.Tasks;

    using AirportEf.DAL.Entities;

    using Xunit;

    public class PilotsTests
    {
        [Collection("Common Server Collection")]
        public class GetPilotsTests
        {
            private readonly TestFixture _fixure;
            public GetPilotsTests(TestFixture fixture)
            {
                _fixure = fixture;
            }

            [Fact]
            public async Task Index_Get_ReturnsIndexHtmlPage_ListingEveryArticle()
            {
                // Act
                var response = await _fixure.Client.GetAsync("/api/pilots");

                // Assert
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                //foreach (var article in PredefinedData.Articles)
                //{
                //    Assert.Contains($"<li data-articleid=\"{ article.ArticleId }\">", responseString);
                //}
            }

            [Fact]
            public async Task Details_Get_ReturnsHtmlPage()
            {
                // Act
                var response = await _fixure.Client.GetAsync($"/api/pilots/2");

                // Assert
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                //  Assert.Contains(PredefinedData.Articles[0].Contents, responseString);
            }
        }

        //[Theory]
        //[InlineData(new Pilot(){ })]
        //[InlineData(5)]
        //public async Task Create_Get_ReturnsHtmlPage(Pilot pilot)
        //{
        //    // Arrange
            

        //    // Act
            

        //    // Assert
            
        //}

        //[Fact]
        //public async Task Create_Get_ReturnsHtmlPage()
        //{
        //    // Arrange
        //    await EnsureAuthenticationCookie();

        //    // Act
        //    var response = await _client.GetAsync("/Articles/Create");

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var responseString = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("<h4>Create new article</h4>", responseString);
        //}

        //[Fact]
        //public async Task Create_Post_RedirectsToList_AfterCreatingArticle()
        //{
        //    // Arrange
        //    await EnsureAuthenticationCookie();
        //    var formData = await EnsureAntiforgeryTokenForm(new Dictionary<string, string>
        //    {
        //        { "Title", "mock title" },
        //        { "Abstract", "mock abstract" },
        //        { "Contents", "mock contents" }
        //    });

        //    // Act
        //    var response = await _client.PostAsync("/Articles/Create", new FormUrlEncodedContent(formData));

        //    // Assert
        //    Assert.Equal(HttpStatusCode.Found, response.StatusCode);
        //    Assert.Equal("/Articles", response.Headers.Location.ToString());
        //}

        //[Fact]
        //public async Task Delete_Get_ReturnsHtmlPage()
        //{
        //    // Arrange
        //    await EnsureAuthenticationCookie();

        //    // Act
        //    //var response = await _client.GetAsync($"/Articles/Delete/{PredefinedData.Articles[0].ArticleId}");

        //    //// Assert
        //    //response.EnsureSuccessStatusCode();
        //    //var responseString = await response.Content.ReadAsStringAsync();
        //    //Assert.Contains("<h3>Are you sure you want to delete this?</h3>", responseString);
        //}

        //[Fact]
        //public async Task DeleteConfirmation_RedirectsToList_AfterDeletingArticle()
        //{
        //    // Arrange
        //    await EnsureAuthenticationCookie();
        //    var formData = await EnsureAntiforgeryTokenForm();

        //    // Act
        //    //var response = await _client.PostAsync($"/Articles/Delete/{PredefinedData.Articles[0].ArticleId}", new FormUrlEncodedContent(formData));

        //    //// Assert
        //    //Assert.Equal(HttpStatusCode.Found, response.StatusCode);
        //    //Assert.Equal("/Articles", response.Headers.Location.ToString());
        //}
    }
}
