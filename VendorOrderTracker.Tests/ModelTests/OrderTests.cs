using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      // Arrange
      string description = "test";
      decimal price = 10.99M;
      
      // Act
      Order newOrder = new Order(description, price);
      
      // Assert
      Assert.AreEqual(typeof(Order), newOrder.GetType());
      }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "3 loafs of bread.";
      decimal price = 10.99M;

      //Act
      Order newOrder = new Order(description, price);
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      // Arrange
      string description = "test";
      decimal price = 10.99M;

      // Act
      Order newOrder = new Order(description, price);

      // Assert
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      //Arrange
      string description01 = "3 loafs of bread";
      decimal price01 = 10.99M;
      string description02 = "2 pastries";
      decimal price02 = 7.49M;
      Order newOrder1 = new Order(description01, price01);
      Order newOrder2 = new Order(description02, price02);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      //Arrange
      string description01 = "3 loafs of bread";
      decimal price01 = 10.99M;
      string description02 = "2 pastries";
      decimal price02 = 7.49M;
      Order newOrder1 = new Order(description01, price01);
      Order newOrder2 = new Order(description02, price02);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      
      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }

    [TestMethod]
    public void GetPrice_ReturnsPrice_Decimal()
    {
    // Arrange
    decimal expectedPrice = 10.99M;
    string description = "2 pastries";
    

    // Act
    Order result = new Order(description, expectedPrice); 

    // Assert
    decimal actualPrice = result.Price;
    Assert.AreEqual(expectedPrice, actualPrice);
    }
  }
}