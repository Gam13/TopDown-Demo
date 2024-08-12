using Godot;
using System;
using System.Collections.Generic;

public static class ItemDatabase
{
    private static Player player;

    public static void Initialize(Player playerInstance)
    {
        player = playerInstance;
    }

    private static Dictionary<string, Item> items = new Dictionary<string, Item>
    {
        { 
            "Godot", 
            new Item(
                "Godot", 
                "res://icon.svg", 
                "An icon representing the Godot engine.",
                () => GD.Print("This is the Godot item!") // Comportamento ao usar o item
            )
        },
        { 
            "Potion", 
            new Item(
                "Potion", 
                "res://potion.png", 
                "Heals 50 health points.",
                () =>
                {
                    // Usa a referência do player para curar
                    player.Heal(50);
                }
            )
        },
        // Adicione outros itens aqui
    };

    public static Item GetItem(string name)
    {
        if (items.ContainsKey(name))
            return items[name];
        return null; // Retorne null se o item não existir
    }
}
