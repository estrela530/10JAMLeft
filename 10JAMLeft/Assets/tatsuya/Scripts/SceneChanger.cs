using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;

    private string currentSceneName;
    private bool isChangeScene = false;

    public bool IsChangeScene
    {
        get => isChangeScene;
        set => isChangeScene = value;
    }

    public string NextSceneName
    {
        get => nextSceneName;
        set => nextSceneName = value;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ButtonChangScene(string nextScene)
    {
        ChangeScene(nextScene);
    }

    public void CurrentChangeScene()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
