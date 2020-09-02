using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int gameScene;
    SaveLoadManager levelLoader;

    private void Awake()
    {
        levelLoader = FindObjectOfType<SaveLoadManager>();
    }

    public void NewGame()
    {
        Click();
        levelLoader.LoadLevel(gameScene, true);
    }

    public void LoadGame()
    {
        Click();
        levelLoader.LoadLevel(gameScene, false);
    }

    public void Exit()
    {
        Click();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit ();
#endif
    }

    void Click()
    {
        FindObjectOfType<AudioManager>().Play("Click01");
    }

    private void OnMouseEnter()
    {
        Click();
    }
}