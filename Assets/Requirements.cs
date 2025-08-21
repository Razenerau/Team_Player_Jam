using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirements : MonoBehaviour
{
    public static Requirements Instance;

    public bool IsPaperMet;
    public bool IsMetalMet;
    public bool IsPlasticMet;

    public int NumOfRequirementsMet;

    private void Awake()
    {
        Instance = this;
    }
}
