﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product{ProductId=1,Name="P1"},
                     new Product{ProductId=2,Name="P2"},
                     new Product{ProductId=3,Name="P3"},
                     new Product{ProductId=4,Name="P4"},
                     new Product{ProductId=5,Name="P5"},

            });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;
         //   IEnumerable<Product> Result =//(IEnumerable<Product>)controller.List(2).Model;
      /// Product[] Product= resu

        }
    }
}
