using Godot;
using System;
using System.Collections.Generic;

public enum eSceneNames {
    Debug = 100,
}

public partial class SceneManager : Node {

    public static SceneManager instance;

    public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>() {
        {eSceneNames.Debug, new SceneData("res://Scenes/100_DebugRoom.tscn", "Debug Room Prettier", false) },
        
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