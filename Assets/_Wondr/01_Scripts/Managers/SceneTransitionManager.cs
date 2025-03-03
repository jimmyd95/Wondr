using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }

    [SerializeField] private GameObject _loadingScreen;

    
    private void Awake()
    {
        // Singleton check
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_loadingScreen);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    [Tooltip("Asynchronously load a scene using the SceneTransitionManager Instance")]
    public void LoadScene(int sceneId, LoadSceneMode sceneMode = LoadSceneMode.Single)
    {
        StartCoroutine(LoadSceneAsync(sceneId, sceneMode));
    }

    // Asynchronously loads a given scene
    private IEnumerator LoadSceneAsync(int sceneId, LoadSceneMode sceneMode)
    {
        // TODO: Add a fade-out effect here

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            yield return null;
        }

        _loadingScreen.SetActive(false);

        // TODO: Add a fade-in effect here
    }

    [Tooltip("Asynchronously unloads a given scene")]
    public void UnloadScene(int sceneId)
    {
        SceneManager.UnloadSceneAsync(sceneId);
    }
}
