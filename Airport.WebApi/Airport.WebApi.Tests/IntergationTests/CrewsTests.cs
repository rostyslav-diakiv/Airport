namespace Airport.WebApi.Tests.IntergationTests
{
    using System.Threading.Tasks;

    using Xunit;

    public class CrewsTests
    {
        [Collection("Common Server Collection")]
        public class GetCrewsTests
        {
            private readonly TestFixture _fixure;

            public GetCrewsTests(TestFixture fixture)
            {
                _fixure = fixture;
            }

            [Fact]
            public async Task Index_Get_ReturnsIndexHtmlPage_ListingEveryArticle()
            {
                // Act
                var response = await _fixure.Client.GetAsync("/api/crews");

                // Assert
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                //foreach (var article in PredefinedData.Articles)
                //{
                //    Assert.Contains($"<li data-articleid=\"{ article.ArticleId }\">", responseString);
                //}
            }
        }
    }
}
