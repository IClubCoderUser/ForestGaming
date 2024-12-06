using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);
    }
}


