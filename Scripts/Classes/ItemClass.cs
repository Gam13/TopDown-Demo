using Godot;
using System;

[GlobalClass] public partial class Item : Resource
{
    [Export] public string Name { get; set; }
    [Export] public string Description { get; set; }
    [Export] public string ImagePath { get; set; }

    [Export] public bool Consumable { get; set; } 
    [Export] public bool Stackable { get; set; }

    public Action OnUse { get; set; }

    // Construtor opcional
    public Item(string name, string description, string imagePath, bool consumable, bool stackable, Action onUse = null)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
        Consumable = consumable;
        Stackable = stackable;
        OnUse = onUse;
    }
}
