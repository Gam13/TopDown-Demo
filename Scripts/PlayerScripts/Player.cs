using Godot;
using System;
using System.Linq;

public partial class Player : Node2D
{
    readonly short MaxHp = 100;
    [Export] int healthpoints = 100;

    [Export] public Godot.Collections.Dictionary<string, int> Inventory = new Godot.Collections.Dictionary<string, int>();

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
        // Obtém o item a partir do banco de dados
        Item item = ItemDatabase.GetItem(itemName);

        // Verifica se o item existe e se está no inventário
        if (item != null && Inventory.ContainsKey(itemName))
        {
            // Executa a ação de uso do item
            item.OnUse?.Invoke();

            // Verifica se o item é consumível
            GD.Print($"{item.Stackable}");
            if (item.Consumable)
            {
                // Remove uma unidade do item do inventário
                RemoveItemFromInventory(item.Name, 1);
            }
        }
    }


    private void ItemInteractedEventHandler(string item, int quantity)
    {
        if (ItemDatabase.GetItem(item) != null && item.Length > 0 && quantity > 0)
        {
            GD.Print($"Item Received: {item}, Quantity: {quantity}");
            AddItemToInventory(item, quantity);
        }

    }
}
