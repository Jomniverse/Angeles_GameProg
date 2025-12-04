using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenuManager : MonoBehaviour
{
    
    [SerializeField] private Button startGame;
    [SerializeField] private Button back;
    [SerializeField] private Button exitGame;
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private GameObject mainMenu;

    public GameObject soundSettings;

    public void LoadlvlBtn(string leveltoLoad)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(leveltoLoad));
    }
    public void ShowSoundPanel()
    {
        soundSettings.SetActive(true);
    }

    IEnumerator LoadLevelAsync(string leveltoLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(leveltoLoad);
        loadOperation.allowSceneActivation = false;

         float duration = 15f;
         float timer = 0f;

        while (timer < duration)
        {
             timer += Time.deltaTime;  
            yield return null;
        }

        loadOperation.allowSceneActivation = true;
    }

    public void Back()
    {
        soundSettings.SetActive(false);
    }

     public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
