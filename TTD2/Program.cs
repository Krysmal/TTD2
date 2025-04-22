using System;
using System.Collections.Generic; 
using System.Linq;  



public class ShoppingCart 
{   
    private List<Item> items; 
    public ShoppingCart() { items = new List<Item>(); } 
    public void AddItem(string name, double price, int quantity) 
    {
        if (price < 0 || quantity <= 0)         
        { throw new ArgumentException("Price and quantity must be positive."); 
        } 
        items.Add(new Item(name, price, quantity)); 
    } 
    public void RemoveItem(string name) 
    {   
        var item = items.FirstOrDefault(i => i.Name == name); 
        if (item == null) 
        { 
            throw new ArgumentException("Item not found in the cart."); 
        } 
        items.Remove(item); 
    } 
    public double GetTotalPrice() 
    { 
        return items.Sum(i => i.Price * i.Quantity); 
    } 
    public void ClearCart() { items.Clear(); 
    } 
    public List<Item> GetItems() { return items; } 
    }
public class Item 
{ 
    public string Name { get; } 
    public double Price { get; } 
    public int Quantity { get; }
    public Item(string name, double price, int quantity) { Name = name; Price = price; Quantity = quantity; } 
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ShoppingCartApp uruchomione.");
        
    }
}