﻿using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Xunit;
using WebApplication1.Controllers;


namespace WebApplication1.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Contact()
        {
            var cr = new ConfigurationRoot(new List<IConfigurationProvider> {new MemoryConfigurationProvider(new MemoryConfigurationSource())});
            cr["kEY1"] = "keyValue1";
            cr["key2"] = "keyValue2";
            cr["USERNAME"] = "SNeagu";
            IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());


            // Arrange
            HomeController controller = new HomeController(cr, cache);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.Equal("keyValue1 SNeagu", result.ViewBag.Message);
        }
    }
}
