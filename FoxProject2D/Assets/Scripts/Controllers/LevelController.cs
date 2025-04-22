using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    public string nextScene = "VictoryScene";
    public float levelTime = 120.0f;
    float currentTime = 0.0f;

    GameObject bushParent;
    int totalBushes;
    int remainBushes;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bushText;

    void Start()
    {
        bushParent = GameObject.Find("Bushes");
        totalBushes = bushParent.transform.childCount;
        UpdateBushes();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        
        UpdateTimer();
        UpdateBushes();

        if (currentTime >= levelTime)
        {
            OnSceneChange("DefeatScene");
        }
    }

    void UpdateTimer()
    {
        int minutes = (int)(levelTime - currentTime)/60;
        int seconds = (int)(levelTime - currentTime)%60;
        if (seconds >= 10)
        {
            timeText.text = minutes + ":" + seconds;
        }
        else
        {
            timeText.text = minutes + ":0" + seconds;
        }
    }

    void UpdateBushes()
    {
        remainBushes = bushParent.transform.childCount;
        bushText.text = remainBushes + "/" + totalBushes;

        if (remainBushes == 0)
        {
            OnSceneChange(nextScene);
        }
    }
    
    public void PlaySound(string name)
    {
        SoundManager.instance.Play(name);
    }

    public void OnSceneChange(string sceneName)
    {
        GameController.instance.OnSceneChange(sceneName);
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
