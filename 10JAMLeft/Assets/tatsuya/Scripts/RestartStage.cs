using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartStage : MonoBehaviour
{
    private SceneSave sceneSave;
    private string restartScene;
    private SceneChanger sceneChange;

    public void ReStartGame()
    {
        sceneSave = FindObjectOfType<SceneSave>();
        sceneChange = FindObjectOfType<SceneChanger>();
        restartScene = sceneSave.BeforScene;
        sceneChange.ChangeScene(restartScene);
    }
}
