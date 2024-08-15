using Godot;
using System;

public partial class Inventory : Control
{
    [Export] private PlayerData playerData { get; set; }
    private PackedScene buttonScene;
    private VBoxContainer buttonsContainer;
    private bool needsUpdate = true;  // Flag para determinar se a UI precisa ser atualizada

    public override void _Ready()
    {
        buttonsContainer = GetNode<VBoxContainer>("TabContainer/Itens/VBoxContainer");
        playerData = GetNode<PlayerData>("/root/PlayerData");

        // Carrega a cena do botão
        buttonScene = GD.Load<PackedScene>("res://Scenes/UI/InventoryButton.tscn");

        // Atualiza a UI do inventário inicialmente
        UpdateInventoryUI();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("inventory"))
        {
            UpdateInventoryUI();
        }
    }

    private void UpdateInventoryUI()
    {
        // Limpa os botões antigos
        foreach (Button button in GetTree().GetNodesInGroup("InventoryButtons"))
        {
            button.QueueFree();
        }

        // Adiciona botões para cada item no inventário
        foreach (var itemEntry in playerData.Inventory)
        {
            var button = buttonScene.Instantiate<InventoryButton>();
            button.Item = itemEntry.Key;
            button.Quantity = itemEntry.Value;
            buttonsContainer.AddChild(button);
        }
    }


}
