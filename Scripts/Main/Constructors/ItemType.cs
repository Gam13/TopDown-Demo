using Godot;
using System;

[GlobalClass] public partial class ItemType : Resource
{
    [Export] public string Name { get; set; }
    [Export] public string Description { get; set; }
    [Export] public string ImagePath { get; set; }

    [Export] public bool Consumable { get; set; }
    public Action OnUse { get; set; }

    // Construtor opcional
    public ItemType(string name, string description, string imagePath,bool consumible, Action onUse = null)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
        Consumable = consumible;
        OnUse = onUse;
    }
}