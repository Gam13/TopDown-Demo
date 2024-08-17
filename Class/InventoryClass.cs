using Godot;
using System;


public partial class Inventory : Resource
{
    public Godot.Collections.Dictionary<Item, int> itemList = new Godot.Collections.Dictionary<Item, int>();

    public void AddItem(Item item, int quantity)
    {
        if (itemList.ContainsKey(item))
        {
            itemList[item] += quantity;
        }
        else
        {
            itemList[item] = quantity;
        }
    }

    public void RemoveItem(Item item, int quantity)
    {

        if (itemList.ContainsKey(item))
        {
            itemList[item] -= quantity;
            if (itemList[item] <= 0)
            {
                itemList.Remove(item);
            }
        }
    }

    public void UseItem(Item item)
    {

        if (item != null && itemList.ContainsKey(item))
        {
            item.OnUse();
            if (item is Consumible) RemoveItem(item, 1);
        }
    }
    public bool HasItem(Item item)
    {
        return itemList.ContainsKey(item);
    }

    public int GetAmount(Item item)
    {
        if (HasItem(item))
        {
            return itemList[item];
        }
        return 0;
    }



}