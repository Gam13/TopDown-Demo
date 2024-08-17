using Godot;
using System;

[GlobalClass]public partial class Consumible: Item
{
    [Export]private int amount;
    [Export]bool percentual;
    [Export] PlayerData data;
    public override void OnUse()
    {
        if(percentual){
            double healAmount = (double)amount / 100 * data.MAX_LIFE;
            data.life += (int)Math.Clamp(healAmount, 0, data.MAX_LIFE);
        }
        else{
            data.life += (int)Math.Clamp(amount, 0, data.MAX_LIFE);
        }
    }
}