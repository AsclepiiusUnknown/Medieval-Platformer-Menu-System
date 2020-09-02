using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    #region |Variables
    #region ||Loading Bar
    [Header("Loading Bar")]
    public GameObject loadingScreen;
    public Slider loadingBar;
    #endregion

    public static bool isNewGame = true;
    #endregion

    #region Loading Bar
    public void LoadLevel(int sceneindex, bool newGame)
    {
        isNewGame = newGame;
        if (isNewGame)
        {
            SaveSystem.NewCube();
        }

        StartCoroutine(LoadAsynchronously(sceneindex));
    }

    IEnumerator LoadAsynchronously(int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;

            yield return null;
        }
    }
    #endregion
}