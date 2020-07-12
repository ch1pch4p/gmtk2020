using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int sceneNum = 1;
    private GameObject cat;
    private GameObject destination;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ProceedToNextLevel()
    {
        SceneManager.LoadScene("level" + sceneNum++);
        cat = GameObject.FindGameObjectWithTag("cat");
        GameObject catStart = GameObject.FindGameObjectWithTag("catStart");
        cat.transform.position = catStart.transform.position;
        destination = GameObject.FindGameObjectWithTag("destination");
    }
}
