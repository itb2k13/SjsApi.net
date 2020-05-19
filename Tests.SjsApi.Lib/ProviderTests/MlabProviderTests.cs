using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SjsApi.Lib.Providers;
using SjsApi.Models;

namespace Tests.SjsApi.Lib.ProviderTests
{
    [TestFixture]
    public class MlabProviderTests
    {
        readonly ContentSection _content = new ContentSection()
        {
            Path = "base/test",
            Title = "Test Content",
            Projects = new List<Project>
            {
                new Project(){Title = "Test Project"}
            }
        };

        private IMlabProvider _provider;

        [OneTimeSetUp]
        public void Setup()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _provider = new MlabProvider(config);
        }

        [Test]
        public async Task Add_Returns_Model()
        {
            var result = await _provider.Add("base/test", _content);

            Assert.That(result.Projects.Count(), Is.GreaterThan(0));
        }

        [Test]
        public async Task Get_Returns_Model()
        {
            var result = await _provider.Get("base/test");

            Assert.That(result.Projects.Count(), Is.GreaterThan(0));
        }

        [Test]
        public async Task Set_Returns_Model()
        {
            var result = await _provider.Set("base/test", _content);

            Assert.That(result.Projects.Count(), Is.GreaterThan(0));
        }


        [OneTimeTearDown]
        public async Task Delete_Returns_True()
        {
            var result = await _provider.Delete("base/test");
        }
    }
}