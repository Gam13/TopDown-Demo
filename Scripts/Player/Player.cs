using Godot;
using System;
using System.Linq;

public partial class Player : Node2D
{
    [Export]private PlayerData playerData { get; set; }
    private Control inventory;
    public override void _Ready()
    {
        ItemDatabase.Initialize(this);
        playerData = GetNode<PlayerData>("/root/PlayerData");
        inventory = GetNode<Control>("CanvasLayer/Inventory");
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
            if(inventory.Visible)inventory.Hide();
            else inventory.Show();
        }
    }

    public void Heal(int amount)
    {
        playerData.healthpoints += amount;
        playerData.healthpoints = Mathf.Clamp(playerData.healthpoints, 0, playerData.MaxHp);
    }

    public void AddItemToInventory(Item itemName, int quantity)
    {

        if (playerData.Inventory.ContainsKey(itemName))
        {
            playerData.Inventory[itemName] += quantity;
        }
        else
        {
            playerData.Inventory[itemName] = quantity;
        }
    }

    public void RemoveItemFromInventory(Item itemName, int quantity)
    {

        if (playerData.Inventory.ContainsKey(itemName))
        {
            playerData.Inventory[itemName] -= quantity;
            if (playerData.Inventory[itemName] <= 0)
            {
                playerData.Inventory.Remove(itemName);
            }
        }
    }

    public void UseItem(Item itemName)
    {
        // Obtém o item a partir do banco de dados
        Item item = ItemDatabase.GetItem(itemName.Name);

        // Verifica se o item existe e se está no inventário
        if (item != null && playerData.Inventory.ContainsKey(itemName))
        {
            item.OnUse?.Invoke();
            if (item.Consumable) RemoveItemFromInventory(item, 1);
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
            AddItemToInventory(dbItem, quantity);
        }
        else
        {
            GD.PrintErr($"Item not found in database or invalid quantity. Item Name: {item.Name}, Quantity: {quantity}");
        }
    }

}
