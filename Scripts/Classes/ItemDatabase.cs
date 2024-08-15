using Godot;
using System;

[GlobalClass]
public partial class ItemDatabase : Resource
{

    private static Player player;
    public static void Initialize(Player playerInstance)
    {
        player = playerInstance;
    }

    [Export] private static Godot.Collections.Dictionary<string, Item> items = new Godot.Collections.Dictionary<string, Item>
    {
        { 
            "Potion", 
            new Item(
                "Potion",                   // Nome
                "res://potion.png",         // Imagem do Item
                "Heals 50 health points.",  // Descrição
                true,                       // Consumível
                true,                       // Estacável no inventário
                () =>                       // OnUse
                {
                    player.Heal(50);        // Usa a referência do player para curar
                }
            )
        },
        { 
            "Weak Potion", 
            new Item(
                "Weak Potion",              // Nome
                "res://potion.png",         // Imagem do Item
                "Heals 30 health points.",  // Descrição
                true,                       // Consumível
                true,                       // Estacável no inventário
                () =>                       // OnUse
                {
                    player.Heal(30);        // Usa a referência do player para curar
                }
            )
        },
        // Adicione outros itens aqui
    };

    public static Item GetItem(string name)
    {
        items.TryGetValue(name, out var item);
        return item;
    }
    
    public static Godot.Collections.Dictionary<string, Item> GetAllItems()
    {
        return items;
    }
}
