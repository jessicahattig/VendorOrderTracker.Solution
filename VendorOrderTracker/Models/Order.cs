using System;
using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Order
  {
    public string Description { get; set; }
    public int Id { get; }
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }
    private static List<Order> _instances = new List<Order> { };

  public Order(string description, decimal price, DateTime orderDate)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
      Price = price;
      OrderDate = orderDate;
    }

  public static List<Order> GetAll()
    {
      return _instances;
    }
    
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}