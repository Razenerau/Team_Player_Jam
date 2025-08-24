using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Requirements : MonoBehaviour
{
    public static Requirements Instance;

    public List<Requirement> RequirementList;

    public bool areReqMet = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (var req in RequirementList)
        {
            req.text.SetText(req.name + ": " + req.number + " Left");
        }
    }

    public void OnTrashRecycled(string tag)
    {
        ScoreController.trashRecycled++;

        Requirement req = RequirementList.Find(r => r.name == tag);
        if (req == null) return; // Update score

        if (req.number > 0)
        {
            req.number--;
            req.text.SetText(req.name + ": " + req.number + " Left");

            if (req.number == 0)
            {
                // bin is complete, show it visually
                SpriteRenderer sr = req.bin.GetComponent<SpriteRenderer>();
                if (sr != null) sr.color = Color.green;

                RecycleController recycleController = req.bin.GetComponent<RecycleController>();
                recycleController.DefaultColor = Color.green;
            }
        }

        CheckIfAllComplete();
    }

    public void OnTrashMisplaced()
    {
        ScoreController.trashMisplaced++;
    }

    private void CheckIfAllComplete()
    {
        foreach (Requirement req in RequirementList)
        {
            if (req.number > 0) return; // Still something left
        }

        areReqMet = true;

        //StartCoroutine(End());
    }

    public void AddRequirement(string tag, int count, TextMeshProUGUI uiText, GameObject bin)
    {
        bin.SetActive(true);
        Requirement newReq = new Requirement
        {
            name = tag,
            number = count,
            text = uiText,
            bin = bin
        };
        newReq.text.SetText(newReq.name + ": " + newReq.number + " Left");
        RequirementList.Add(newReq);
    }

    public void RemoveRequirment(string tag)
    {

    }
}

[System.Serializable]
public class Requirement
{
    public string name;
    public TextMeshProUGUI text;
    public GameObject bin;

    [Header("Score")]
    public int number;
}
