using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{

    public void PlaySound(string name)
    {
        SoundManager.instance.Play(name);
    }

    public void OnSceneChange(string sceneName)
    {
        GameController.instance.OnSceneChange(sceneName);
    }

    public void OnRestart()
    {
        GameController.instance.OnRestart();
    }

    public void Pause()
    {
        GameController.instance.PauseGame();
    }

    public void UnPause()
    {
        GameController.instance.UnPauseGame();
    }

}
