using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject Panel;
    public void NextScene()
    {
        
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);

        DestroyGameObject();

    }
    void DestroyGameObject()
    {
        Destroy(Panel);
    }
}
