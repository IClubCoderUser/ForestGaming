using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniButton : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
            

    }
}
