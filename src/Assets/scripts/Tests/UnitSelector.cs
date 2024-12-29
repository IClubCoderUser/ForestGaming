// Change the mesh color in response to mouse actions.

using UnityEngine;
using System.Collections;

public class UnitSelector : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        rend.material.color = new Color(0.9f, 0.4f, 0.4f, 0.8f);
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
}