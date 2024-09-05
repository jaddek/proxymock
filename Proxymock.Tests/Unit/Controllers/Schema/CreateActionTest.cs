using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Schema;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Schema;
using Proxymock.API.Domain.Project.Schema.Request;

namespace Proxymock.Tests.Unit.Controllers.Schema
{
    public class CreateActionTest
    {
        private static EndpointRepository GetEndpointRepository()
        {
            API.Entities.Project project = new()
            {
                Title = "TestTitle"
            };


            API.Entities.Endpoint endpoint = new()
            {
                Url = "TestUrl",
                Project = project,
            };
        
            Mock<EndpointRepository> mockEndpointRepo = new(null!);
            mockEndpointRepo.Setup(static m => m.FindProjectEndpoint(It.IsAny<API.Entities.Project>(), It.IsAny<Guid>())).ReturnsAsync(endpoint);

            return mockEndpointRepo.Object;
        }
        
        private static SchemaRepository GetSchemaRepository()
        {
            API.Entities.Schema schema = new()
            {
                Title = "TestTitle"
            };

            Mock<SchemaRepository> mockSchemaRepository = new(null!);
            mockSchemaRepository.Setup(static m => m.FindOneAsync(It.IsAny<Guid>())).ReturnsAsync(schema);

            return mockSchemaRepository.Object;
        }
    
        private static ProjectRepository GetProjectRepository()
        {
            API.Entities.Project project = new()
            {
                Title = "TestTitle"
            };

            Mock<ProjectRepository> mockProjectRepository = new(null!);
            mockProjectRepository.Setup(static m => m.FindOneAsync(It.IsAny<Guid>())).ReturnsAsync(project);

            return mockProjectRepository.Object;
        }

        private static CreateAction GetController()
        {
            ProjectRepository projectRepository = GetProjectRepository();
            EndpointRepository endpointRepository = GetEndpointRepository();
            SchemaRepository schemaRepository = GetSchemaRepository();
        
            return new(projectRepository,endpointRepository, schemaRepository);
        }


        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb", "1d534d25-3c99-45cd-a022-7d9e7db15ebb")]

        public async Task CreateSchemeTest_Success(Guid projectId, Guid endpointId)
        {
            SchemaDto schema = new()
            {
                Title = "TestTitle"
            };
            
            var result = await GetController().Invoke(projectId, endpointId, schema);
        
            Assert.IsAssignableFrom<ActionResult>(result);
        }
    }
}