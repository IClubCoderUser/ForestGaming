using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoController : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClick () 
    {
        panel.SetActive(!panel.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
