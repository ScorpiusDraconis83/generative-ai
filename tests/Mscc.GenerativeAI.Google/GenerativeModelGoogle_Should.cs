using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Google;
using Mscc.GenerativeAI.Types;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Test.Mscc.GenerativeAI.Google
{
    [Collection(nameof(ConfigurationFixture))]
    public class GenerativeModelGoogle_Should(ITestOutputHelper output, ConfigurationFixture fixture)
    {
        private readonly string _model = Model.Gemini25Pro;

        [Fact]
        public async Task Initiate()
        {
            // Arrange
            // Act
            var vertex = await GenerativeModelGoogle.CreateAsync();

            // Assert
            vertex.ShouldNotBeNull();
        }

        [Fact]
        public async Task Initiate_Static_OAuth()
        {
            // Arrange
            // Act
            GenerativeModelGoogle vertex = await GenerativeModelGoogle.CreateAsync();

            // Assert
            vertex.ShouldNotBeNull();
        }

        [Fact]
        public void Initiate_Static_ServiceAccount()
        {
            // Arrange
            //var serviceAccount = "";
            
            // Act
            var vertex = GenerativeModelGoogle.CreateInstance(fixture.ServiceAccount, passphrase:fixture.Passphrase);
            
            // Assert
            vertex.ShouldNotBeNull();
        }

        [Fact]
        public async Task Initiate_With_OAuth()
        {
            // Arrange
            // Act
            var vertex = await GenerativeModelGoogle.CreateAsync();
            vertex.ProjectId = fixture.ProjectId;
            vertex.Region = fixture.Region;

            // Assert
            vertex.ShouldNotBeNull();
        }

        [Fact]
        public void Initiate_With_ServiceAccount()
        {
            // Arrange & Act
            var vertex = GenerativeModelGoogle.CreateInstance(fixture.ServiceAccount, passphrase:fixture.Passphrase)
                .WithProjectId(fixture.ProjectId)
                .WithRegion(fixture.Region);
        
            // Assert
            vertex.ShouldNotBeNull();
        }

        [Fact]
        public async Task Initiate_Default_Model()
        {
            // Arrange
            var vertex = await GenerativeModelGoogle.CreateAsync();
            vertex.ProjectId = fixture.ProjectId;
            vertex.Region = fixture.Region;
            
            // Act
            var model = await vertex.CreateModelAsync();

            // Assert
            model.ShouldNotBeNull();
            model.Name.ShouldBe(Model.Gemini25Pro.SanitizeModelName());
        }

        [Theory]
        [InlineData(Model.Gemini25Pro)]
        [InlineData(Model.Gemini20Pro)]
        public async Task Initiate_Model(string expected)
        {
            // Arrange
            var vertex = await GenerativeModelGoogle.CreateAsync();
            vertex.ProjectId = fixture.ProjectId;
            vertex.Region = fixture.Region;
            
            // Act
            var model = await vertex.CreateModelAsync(expected);

            // Assert
            model.ShouldNotBeNull();
            model.Name.ShouldBe(expected.SanitizeModelName());
        }

        [Fact]
        public async Task List_Models()
        {
            // Arrange
            var vertex = await GenerativeModelGoogle.CreateAsync();
            vertex.ProjectId = fixture.ProjectId;
            vertex.Region = fixture.Region;
            var model = await vertex.CreateModelAsync(model: _model);

            // Act & Assert
            await Assert.ThrowsAsync<NotSupportedException>(() => model.ListModels());
        }

        [Fact]
        public async Task List_Models_With_ServiceAccount()
        {
            // Arrange
            var vertex = GenerativeModelGoogle.CreateInstance(fixture.ServiceAccount, passphrase:fixture.Passphrase)
                .WithProjectId(fixture.ProjectId)
                .WithRegion(fixture.Region);
            var model = await vertex.CreateModelAsync(model: _model);

            // Act & Assert
            await Assert.ThrowsAsync<NotSupportedException>(() => model.ListModels());
        }
    }
}