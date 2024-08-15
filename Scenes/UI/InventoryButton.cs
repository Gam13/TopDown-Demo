using Godot;
using System;

public partial class InventoryButton : Button
{
    [Export] public Item Item { get; set; }
    [Export] public int Quantity { get; set; }
    [Export] private Player player { get; set; }
    private Label quantityLabel;

    public override void _Ready()
    {
        AddToGroup("InventoryButtons");
        player = GetNode<Player>("/root/Player");
        quantityLabel = GetNode<Label>("Quantity");

        // Atualiza a UI do botão
        UpdateButtonUI();

        // Conecta o sinal do botão ao método OnPressed
        Connect("pressed", new Callable(this, nameof(OnPressed)));
    }

    private void UpdateButtonUI()
    {
        if (Item != null)
        {
            Text = Item.Name;
            quantityLabel.Text = Quantity.ToString();
            quantityLabel.Visible = Item.Stackable;
        }
        else
        {
            Text = "Unknown Item";
            quantityLabel.Visible = false;
        }
    }

    private void OnPressed()
    {
        GD.Print("Teste");
       
            player.UseItem(Item);
        
    }
}
