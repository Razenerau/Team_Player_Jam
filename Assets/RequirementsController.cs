using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RequirementsController : MonoBehaviour
{
    public static RequirementsController instance;
    public GameObject bin;
    public GameObject spawner;
    public TextMeshProUGUI uiText;
    public int currentTime;

    public bool isAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        //bin.SetActive(false);
        spawner.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 120 && !isAdded)
        {
            RecycleController recycleController = bin.GetComponent<RecycleController>();
            string tag = recycleController.TargetTag;
            Requirements.Instance.AddRequirement(tag, ScoreController.trashRecycled, uiText, bin);
            spawner.SetActive(true);

            isAdded = true;
        }
    }
}
