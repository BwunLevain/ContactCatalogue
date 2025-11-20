using ContactCatalogue;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;

namespace ContactCatalogue.test
{

    public class FilterTests
    {
        [Fact]
        public void Search_By_Tag_Returns_Only_Matching()
        {
            var mockRepo = new Mock<IContactRepository>();
            mockRepo.Setup(r => r.GetAll()).Returns(new[]
            {
                new Contact{ Id=1, Name="Anna", Email="a@x.se", Tags = new List<string> { "friend" } },
                new Contact{ Id=2, Name="Bo",   Email="b@x.se", Tags = new List<string> { "work" } }
            });

            var mockLogger = new Mock<ILogger<ContactService>>();

            var svc = new ContactService(mockRepo.Object, mockLogger.Object);

            var result = svc.SearchByTag("friend").ToList();

            Assert.Single(result);
            Assert.Equal("Anna", result[0].Name);
        }
    }
}