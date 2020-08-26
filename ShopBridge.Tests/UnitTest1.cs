using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using System.Web.Mvc;
using DAL;
using BLL;
using System.Collections.Generic;
using System.Linq;

namespace ShopBridge.Tests
{
    [TestClass]
    public class UnitTest1
    {
        int TestID=0;
        [TestMethod]
        public void AllItemDisplay()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult view = controller.AllItemDisplay() as ViewResult;

            //Assert
            Assert.IsNotNull(view);
        }
        [TestMethod]
        public void Details()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult view = controller.Details(0) as ViewResult;

            //Assert
            Assert.IsNotNull(view);
        }
        [TestMethod]
        public void Add()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult view = controller.Add() as ViewResult;

            //Assert
            Assert.IsNotNull(view);
        }
        [TestMethod]
        public void AddItem()
        {
            //Arrange
            HomeController controller = new HomeController();

            ItemModel itemModel = new ItemModel();
            itemModel.Name = "Test";
            //Act
            ViewResult view = controller.Add(itemModel) as ViewResult;

            TestID = view.ViewBag.Id;
            //Assert
            Assert.AreNotEqual(0,TestID);
        }
        [TestMethod]
        public void EditItem()
        {
            //Arrange
            HomeController controller = new HomeController();

            ItemModel itemModel = new ItemModel();
            using (var context = new ShopBridgeDBEntities())
            {
                TestID = context.ItemMasters.Where(x => x.Name == "Test" && x.Description == null).
                    Select(x => x.Id).FirstOrDefault();

            }
            itemModel.Id = TestID;
            itemModel.Name = "Test";
            //Act
            ViewResult view = controller.Edit(itemModel) as ViewResult;

            TestID = view.ViewBag.Id;
            //Assert
            Assert.AreNotEqual(0, TestID);
        }
        [TestMethod]
        public void Delete()
        {
            //Arrange
            HomeController controller = new HomeController();
            using (var context = new ShopBridgeDBEntities())
            {
                TestID = context.ItemMasters.Where(x=>x.Name=="Test" && x.Description==null).
                    Select(x =>x.Id).FirstOrDefault();

            }
            //Act
            ViewResult view = controller.Delete(TestID) as ViewResult;

            //Assert
            Assert.IsNotNull(view);
        }
    }
}
