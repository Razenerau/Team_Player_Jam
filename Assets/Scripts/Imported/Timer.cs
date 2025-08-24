using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 30f;

    public GameObject WinScreen;
    public GameObject GameOverScreen;

    public TextMeshProUGUI GMScoreText;
    public TextMeshProUGUI WScoreText;


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
            OnTimeRunOut();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        timerText.text = Mathf.CeilToInt(currentTime).ToString();
        RequirementsController.instance.currentTime = Mathf.CeilToInt(currentTime);
    }

    void OnTimeRunOut()
    {
        if(Requirements.Instance.areReqMet)
        {
            StartCoroutine(NextScene());
        }
        else
        {
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator NextScene()
    {
        WScoreText.SetText("Trash Recycled: " + ScoreController.trashRecycled.ToString());
        WinScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        LoadNextScene();
    }

    private IEnumerator ReloadScene()
    {
        GMScoreText.SetText("Trash Recycled: " + ScoreController.trashRecycled.ToString()); 
        GameOverScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void LoadNextScene()
    {
        // Get current scene index
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Get total number of scenes in build settings
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Calculate next scene index (wraps around to 0 if at the end)
        int nextIndex = (currentIndex + 1) % totalScenes;

        // Load the next scene
        SceneManager.LoadScene(nextIndex);
    }


}
