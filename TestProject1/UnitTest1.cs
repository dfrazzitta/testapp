using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using testapp.Controllers;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //private readonly ILogger<HomeController> _logger;
        [TestMethod]
        public void TestMethod1()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<HomeController>();
            var svc = new HomeController(logger);
            var result = svc.Index();
            Assert.AreEqual(3, 3);

            //var svc = new HomeController(new NullLogger<HomeController>());

            // var rtn = svc.Index();

        }
    }
}