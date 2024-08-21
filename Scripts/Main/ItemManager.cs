using Godot;
using System;


public enum eItemList {
    Potion = 1,
    WeakPotion = 2,
}
public partial class ItemManager:Node
{   
    public static ItemManager instance;
    [Export] public Godot.Collections.Dictionary<eItemList, ItemType> ItemList = new()
    {
        { 
            eItemList.Potion, 
            new ItemType(
                "Potion",                   // Nome
                "res://icon.svg",         // Imagem do ItemType
                "Heals 50 health points.",  // Descrição
                true,
                () =>                       // OnUse
                {
                }
            )
        },
        { 
            eItemList.WeakPotion, 
            new ItemType(
                "Weak Potion",              // Nome
                "res://icon.svg",         // Imagem do ItemType
                "Heals 30 health points.",  // Descrição
                true,
                () =>                       // OnUse
                {
                }
            )
        },
        // Adicione outros itens aqui
    };
    
    public override void _Ready() {
        instance = this;
    }
    
}