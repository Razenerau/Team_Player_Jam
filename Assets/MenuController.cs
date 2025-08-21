using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Public method to load the "Level_1" scene
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level_1");
    }

}
