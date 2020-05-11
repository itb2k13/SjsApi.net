using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [Test]
        public async Task Add_Returns_Model()
        {
            var provider = new MlabProvider();
            var result = await provider.Add("base/test", _content);

            Assert.That(result.Projects.Count(), Is.GreaterThan(0));
        }

        [Test]
        public async Task Get_Returns_Model()
        {
            var provider = new MlabProvider();
            var result = await provider.Get("base/test");

            Assert.That(result.Projects.Count(), Is.GreaterThan(0));
        }

        [Test]
        public async Task Set_Returns_Model()
        {
            var provider = new MlabProvider();
            var result = await provider.Set("base/test", _content);

            Assert.That(result.Projects.Count(), Is.GreaterThan(0));
        }


        [OneTimeTearDown]
        public async Task Delete_Returns_True()
        {
            var provider = new MlabProvider();
            var result = await provider.Delete("base/test");
        }
    }
}