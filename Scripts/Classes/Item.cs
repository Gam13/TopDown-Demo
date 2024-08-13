using Godot;
using System;

public class Item
{
    public string Name { get; }
    public string Description { get; }
    public string ImagePath { get; }

    public bool Consumable { get; }
    public bool Stackable { get; }
    
    public Action OnUse { get; set; }

    // Atualize o construtor para inicializar todas as propriedades
    public Item(string name, string imagePath, string description, bool consumable, bool stackable, Action onUse)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
        Consumable = consumable;
        Stackable = stackable;   
        OnUse = onUse;
    }
}
