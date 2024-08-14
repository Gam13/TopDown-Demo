using Godot;
using System;
using System.Linq;

public partial class Player : Node2D
{
    readonly short MaxHp = 100;
    [Export] int healthpoints = 100;

    [Export] public Godot.Collections.Dictionary<Item, int> Inventory = new Godot.Collections.Dictionary<Item, int>();

    public override void _Ready()
    {
        ItemDatabase.Initialize(this);

        foreach (Container container in GetTree().GetNodesInGroup("Containers"))
        {
            container.Connect("ItemInteracted", new Callable(this, nameof(ItemInteractedEventHandler)));
        }
    }

    public override void _Process(double delta)
    {
        //Debug using function
        if (Input.IsActionJustPressed("inventory"))
        {
            UseItem(Inventory.Keys.First());
        }
    }

    public void Heal(int amount)
    {
        healthpoints += amount;
        healthpoints = Mathf.Clamp(healthpoints, 0, MaxHp);
        GD.Print($"Player healed by {amount}. Current health: {healthpoints}");
    }

    public void AddItemToInventory(Item itemName, int quantity)
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

    public void RemoveItemFromInventory(Item itemName, int quantity)
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

    public void UseItem(Item itemName)
    {
        // Obtém o item a partir do banco de dados
        Item item = ItemDatabase.GetItem(itemName.Name);

        // Verifica se o item existe e se está no inventário
        if (item != null && Inventory.ContainsKey(itemName))
        {
            item.OnUse?.Invoke();
            if (item.Consumable)RemoveItemFromInventory(item, 1);
        }
    }


    private void ItemInteractedEventHandler(Item item, int quantity)
{
    if (item == null)
    {
        GD.PrintErr("Received a null item in ItemInteractedEventHandler.");
        return;
    }

    if (string.IsNullOrEmpty(item.Name))
    {
        GD.PrintErr("Item name is null or empty.");
        return;
    }

    Item dbItem = ItemDatabase.GetItem(item.Name);

    if (dbItem != null && quantity > 0)
    {
        GD.Print($"Item Received: {item.Name}, Quantity: {quantity}");
        AddItemToInventory(dbItem, quantity);
    }
    else
    {
        GD.PrintErr($"Item not found in database or invalid quantity. Item Name: {item.Name}, Quantity: {quantity}");
    }
}

}
