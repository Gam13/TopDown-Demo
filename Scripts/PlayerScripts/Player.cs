using Godot;
using System;

public partial class Player : Node2D
{
    readonly short MaxHp = 100;
    int healthpoints = 100;

    [Export]public Godot.Collections.Dictionary<string, int> Inventory = new Godot.Collections.Dictionary<string, int>();

    public override void _Ready()
    {
        ItemDatabase.Initialize(this);

        foreach (Container container in GetTree().GetNodesInGroup("Containers"))
        {
            container.Connect("ItemInteracted",new Callable( this, nameof(ItemInteractedEventHandler)));
        }
    }

    public void Heal(int amount)
    {
        healthpoints += amount;
        healthpoints = Mathf.Clamp(healthpoints, 0, MaxHp);
        GD.Print($"Player healed by {amount}. Current health: {healthpoints}");
    }

    public void AddItemToInventory(string itemName, int quantity)
    {
        if (Inventory.ContainsKey(itemName))
        {
            Inventory[itemName] += quantity;
        }
        else
        {
            Inventory[itemName] = quantity;
        }
    }

    public void RemoveItemFromInventory(string itemName, int quantity)
    {
        if (Inventory.ContainsKey(itemName))
        {
            Inventory[itemName] -= quantity;
            if (Inventory[itemName] <= 0)
            {
                Inventory.Remove(itemName);
            }
        }
    }

    public void UseItem(string itemName)
    {
        Item item = ItemDatabase.GetItem(itemName);
        if (item != null && Inventory.ContainsKey(itemName))
        {
            item.OnUse?.Invoke();
        }
    }

    private void ItemInteractedEventHandler(string item, int quantity)
    {
        GD.Print($"Item Received: {item}, Quantity: {quantity}");
        AddItemToInventory(item, quantity);
    }
}
