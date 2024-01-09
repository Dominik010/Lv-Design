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
    public void AufKlick()
    {
        SceneManager.LoadScene(SettingScene.SceneName);
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
