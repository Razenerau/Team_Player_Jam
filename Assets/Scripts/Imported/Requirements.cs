using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Requirements : MonoBehaviour
{
    public static Requirements Instance;

    public float timeLeft;

    public TextMeshProUGUI textPlastic;
    //public TextMeshProUGUI textPaper;
    public TextMeshProUGUI textMetal;

    public int NumOfRequirementsMet;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        if(NumOfRequirementsMet >= 1)
        {
            textMetal.color = Color.green;
            //textPaper.color = Color.green;
            textPlastic.color = Color.green;

            StartCoroutine(End());
        }
        else
        {
            NumOfRequirementsMet++;
        }
            
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End");
    }
}
