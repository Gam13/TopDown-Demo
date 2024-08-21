using Godot;
using System;
using System.Collections.Generic;

public enum eSceneNames {
    MainMenu = 1,
    Debug = 100,
}

public partial class SceneManager : Node {

    public static SceneManager instance;

    public Dictionary<eSceneNames, SceneData> sceneDictionary = new() {

        {eSceneNames.Debug, new SceneData("res://Scenes/100_DebugRoom.tscn", "Debug Room Prettier", true) },
        {eSceneNames.MainMenu, new SceneData("res://Scenes/Main_Menu.tscn", "Main Menu", false) },
    };

    public override void _Ready() {
        instance = this;
    }

    public void ChangeScene(eSceneNames mySceneName) {
        string myPath = sceneDictionary[mySceneName].path;
        GameMaster.pauseAllowed = sceneDictionary[mySceneName].pauseAllowed;
        GetTree().ChangeSceneToFile(myPath);
    }

}