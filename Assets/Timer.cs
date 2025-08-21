using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 30f;

    private float currentTime;
    private bool isCounting = true;

    void Start()
    {
        currentTime = startTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isCounting) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isCounting = false;
            timerText.color = Color.red;
            ReloadScene();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        timerText.text = Mathf.CeilToInt(currentTime).ToString();
        Requirements.Instance.timeLeft = currentTime;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }


}
