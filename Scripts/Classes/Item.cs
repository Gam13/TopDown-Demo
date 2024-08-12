using Godot;
using System;

public class Item
{
    public string Name { get; }
    public string Description { get; }
    public string ImagePath { get; }
    public bool Stackable {get;}
    
    public Action OnUse { get; set; }

    public Item(string name, string imagepath, string description, bool Stackable, Action onUse)
    {
        Name = name;
        Description = description;
        ImagePath = imagepath;
        OnUse = onUse;
    }
}
