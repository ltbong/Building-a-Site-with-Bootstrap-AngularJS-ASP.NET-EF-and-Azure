using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using MessageBoard.Controllers;
using MessageBoard.Data;
using MessageBoard.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace MessageBoard.Tests.Controllers
{
    [TestClass]
    public class TopicsControllerTests
    {
        private TopicsController _ctrl;

        [TestInitialize]
        public void Init()
        {
            _ctrl = new TopicsController(new FakeMessageBoardRepository());
        }

        [TestMethod]
        public void TopicsController_Get()
        {
            var results = _ctrl.Get(true);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
            Assert.IsNotNull(results.First());
            Assert.IsNotNull(results.First().Title);
        }

        [TestMethod]
        public void TopicsController_Post()
        {
            ConfigureWebApiContextForPost(_ctrl);

            var newTopic = new Topic()
            {
                Title = "I am the coolest test topic ever!",
                Body = "Check out this body... Is it the most epic topic body ever??  Smokin' hot!"
            };

            var result = _ctrl.Post(newTopic);

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

            var json = result.Content.ReadAsStringAsync().Result;
            var topic = JsonConvert.DeserializeObject<Topic>(json);

            Assert.IsNotNull(topic);
            Assert.IsTrue(topic.Id > 0);
            Assert.IsTrue(topic.Created > DateTime.MinValue);
        }

        private void ConfigureWebApiContextForPost(TopicsController topicsController)
        {
            // This is basically boilerplate code for testing a post in WebApi... This will probably get easier some day, but not yet.
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/v1/topics");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "topics" } });

            topicsController.ControllerContext = new HttpControllerContext(config, routeData, request);
            topicsController.Request = request;
            topicsController.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }
    }
}
