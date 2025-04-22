using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

[TestFixture]
public class ShoppingCartTests
{
    [Test]
    public void AddItem_AddsValidItem()
    {
        var cart = new ShoppingCart();

        cart.AddItem("Book", 20.0, 2);

        var items = cart.GetItems();
        Assert.That(items.Count, Is.EqualTo(1));
        Assert.That(items[0].Name, Is.EqualTo("Book"));
        Assert.That(items[0].Price, Is.EqualTo(20.0));
        Assert.That(items[0].Quantity, Is.EqualTo(2));
    }

    [Test]
    public void AddItem_Throws_OnNegativePrice()
    {
        var cart = new ShoppingCart();
        Assert.Throws<ArgumentException>(() => cart.AddItem("BadItem", -5.0, 1));
    }

    [Test]
    public void AddItem_Throws_OnZeroQuantity()
    {
        var cart = new ShoppingCart();
        Assert.Throws<ArgumentException>(() => cart.AddItem("BadItem", 10.0, 0));
    }

    [Test]
    public void RemoveItem_RemovesExistingItem()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Laptop", 1000, 1);

        cart.RemoveItem("Laptop");

        Assert.That(cart.GetItems().Any(i => i.Name == "Laptop"), Is.False);
    }

    [Test]
    public void RemoveItem_Throws_IfItemNotFound()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Mouse", 25, 1);

        Assert.Throws<ArgumentException>(() => cart.RemoveItem("Keyboard"));
    }

    [Test]
    public void GetTotalPrice_ReturnsCorrectSum()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Notebook", 10, 3); 
        cart.AddItem("Pen", 2.5, 4);    

        double total = cart.GetTotalPrice();

        Assert.That(total, Is.EqualTo(40));
    }

    [Test]
    public void ClearCart_RemovesAllItems()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Phone", 800, 1);
        cart.AddItem("Case", 25, 2);

        cart.ClearCart();

        Assert.That(cart.GetItems().Count, Is.EqualTo(0));
    }

    [Test]
    public void GetItems_ReturnsCurrentItems()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Water", 1.5, 10);

        var items = cart.GetItems();

        Assert.That(items, Is.Not.Null);
        Assert.That(items.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddItem_CanAddMultipleDifferentItems()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Milk", 3, 1);
        cart.AddItem("Bread", 2, 2);

        var items = cart.GetItems();

        Assert.That(items.Count, Is.EqualTo(2));
    }

    [Test]
    public void AddItem_CanAddHighQuantityAndPrice()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Gold", 9999.99, 100);

        var total = cart.GetTotalPrice();

        Assert.That(total, Is.EqualTo(999999));
    }
}