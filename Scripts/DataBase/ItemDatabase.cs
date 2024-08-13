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
            "Potion", 
            new Item(
                "Potion",                   //Nome
                "res://potion.png",         //Imagem do Item
                "Heals 50 health points.",  //Descrição
                true,                       //Consumível
                true,                       //Estacável no inventário
                () =>                       //OnUse
                {
                    // Usa a referência do player para curar
                    player.Heal(50);
                }
            )
            
        },
        { 
            "Weak Potion", 
            new Item(
                "Weak Potion",                   //Nome
                "res://potion.png",         //Imagem do Item
                "Heals 30 health points.",  //Descrição
                true,                       //Consumível
                true,                       //Estacável no inventário
                () =>                       //OnUse
                {
                    // Usa a referência do player para curar
                    player.Heal(30);
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
