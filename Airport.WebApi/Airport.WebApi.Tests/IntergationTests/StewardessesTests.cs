namespace Airport.WebApi.Tests.IntergationTests
{
    using System.Threading.Tasks;

    using Xunit;

    public class StewardessesTests
    {
        [Collection("Common Server Collection")]
        public class GetStewardessesTests
        {
            private readonly TestFixture _fixure;
            public GetStewardessesTests(TestFixture fixture)
            {
                _fixure = fixture;
            }

            [Fact]
            public async Task Index_Get_ReturnsIndexHtmlPage_ListingEveryArticle()
            {
                // Act
                var response = await _fixure.Client.GetAsync("/api/stewardesses");

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
                var response = await _fixure.Client.GetAsync("/api/stewardesses/2");

                // Assert
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                //  Assert.Contains(PredefinedData.Articles[0].Contents, responseString);
            }
        }
    }
}
