using Godot;
using System;
namespace Managment.Game{
    public partial class GameMaster : Node {

    //Release.Features.Patch
    public static string gameVersion = "0.1.1 Build Date: 9/24/2023";

    //The slot number that the game will save and load to by default
    public static int currentSlotNum = 0;

    public static bool paused = false;
    public static bool pauseAllowed = false;
    public static bool ignoreUserInput = false;

    //Base Player Data
    public static PlayerData playerData = new();

    //Game Data
    public static GameData gameData = new();

    }
}
