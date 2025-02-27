using Cdm.Figma;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }

    // Determines what scene is loaded at application start
    [SerializeField] private int startingScene = 1;


    private void Awake()
    {
        // Singleton check
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        /*** TODO:
         * Add a check to determine if a user is already logged-in.
         * If the user is already logged-in, the first scene should be the application's main AR scene.
         * Otherwise the application should load the log-in screen first
        ***/

        // Starts the application by loading the log-in screen
        SceneTransitionManager.Instance.LoadScene(startingScene, LoadSceneMode.Additive);
    }
}
