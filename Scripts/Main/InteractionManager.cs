using Godot;
using System;
using System.Collections.Generic;

public partial class InteractionManager : Node
{
    public static InteractionManager instance;

    public override void _Ready()
    {
        instance = this;
    }

    public static InteractionComponent FindInteractionComponentInChildren(Node parent)
    {
        // Verifica se o node atual é um InteractionComponent
        if (parent is InteractionComponent interactionComponent)
        {
            return interactionComponent;
        }

        // Busca recursivamente nos filhos
        foreach (Node child in parent.GetChildren())
        {
            var found = FindInteractionComponentInChildren(child);
            if (found != null)
            {
                return found;
            }
        }

        // Nenhum InteractionComponent encontrado
        return null;
    }

    public static void AddItemtoInventory(Godot.Collections.Array<eItemList> newItem)
    {
        foreach (eItemList item in newItem)
        {
            if (ItemManager.instance.ItemList.ContainsKey(item))
            {
                // Acessa o item no dicionário usando o índice
                var itemType = ItemManager.instance.ItemList[item];

                // Adiciona o item ao inventário do jogador
                if (!GameMaster.playerData.inventory.ContainsKey(itemType))
                {
                    GameMaster.playerData.inventory.Add(itemType, 1);
                }
                else
                {
                    GameMaster.playerData.inventory.Add(itemType, +1);
                }
            }
        }
    }



    public static void HandleInteraction(InteractionComponent interactionComponent)
    {
        if (interactionComponent is ContainerComponent containerComponent)
        {
            AddItemtoInventory(containerComponent.Collectables);
        }
    }
}
