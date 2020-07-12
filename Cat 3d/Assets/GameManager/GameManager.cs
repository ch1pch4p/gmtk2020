using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int sceneNum = 1;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ProceedToNextLevel()
    {
        string nextLevelName = "level" + sceneNum++;
        if (Application.CanStreamedLevelBeLoaded(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.Log("Finished all levels!");
        }
    }
}
