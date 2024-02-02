using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] private SceneField LevelScene;
    [SerializeField] private SceneField SettingScene;
    [SerializeField] private SceneField MenuScene;
    public void OnClick()
    {
        SceneManager.LoadScene(LevelScene.SceneName);
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SettingScene.SceneName);
    }
    public void AufKlick()
    {
        StartCoroutine(GameStart());
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScene.SceneName);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
