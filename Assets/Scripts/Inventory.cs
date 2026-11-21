using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _items = new();
    private const int _minCount = 0;
    public int CurrentSize => _items.Sum(item => item.Count);
    public int MaxSize {get;}

    public Inventory(List<Item> items, int maxSize)
    {
        if (maxSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxSize));

        if (items == null)
            throw new ArgumentNullException(nameof(items));

        if (items.Any(item => item == null))
            throw new ArgumentException("список содержит null!");
        
        int initialSize = items.Sum(item => item.Count);

        if (initialSize > maxSize)
            throw new ArgumentException("предметов больше чем поместится в инвентарь!");
        
            _items = new List<Item>(items);
            MaxSize = maxSize;
    }
            
    public int Add(Item item)
    {
        if (item == null || item.Count <= _minCount)
            return _minCount;
        
        int freeSpace = MaxSize - CurrentSize;
        int addedCount = Math.Min(item.Count, freeSpace);
        
        if (addedCount <= _minCount)
            return _minCount;

        _items.Add(new Item(item.Name, addedCount));
        item.Remove(addedCount);
        return addedCount;
    }

    public List<Item> GetItemsBy(string name, int count)
    {
        List<Item> result = new List<Item>();
        
            if (count <= _minCount)
                return result;

        List<Item> foundItems = _items.Where(item => item.Name == name).ToList();
        int remainingCount = count;

        foreach(Item item in foundItems)
        {
            int takeCount = Math.Min(item.Count, remainingCount);
            remainingCount -= takeCount;
            result.Add(new Item(item.Name, takeCount));
            item.Remove(takeCount);

            if(remainingCount == _minCount)
                break;
        }

        _items.RemoveAll(item => item.Count == _minCount);
        return result;
    }
}


public class Item
{
    private int _count;

    public Item(string name, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "имя предмета не может быть пустым");

        Name = name;
        Count = count;
    }
    public string Name {get; private set;}
    
    public int Count
    {
        get => _count;
        private set
        {
            if (value < 0)
                return;

            _count = value;
        }
    }   

    internal void Remove(int count)
    {
        if (count <= 0 || count > Count)
            return;

        Count -= count;
    }
}




        





