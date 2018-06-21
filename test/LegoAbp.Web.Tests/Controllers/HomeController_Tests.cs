using System.Threading.Tasks;
using LegoAbp.Web.Controllers;
using Shouldly;
using Xunit;

namespace LegoAbp.Web.Tests.Controllers
{
    public class HomeController_Tests: LegoAbpWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
