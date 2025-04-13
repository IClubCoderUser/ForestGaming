using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonSelectHelper : MonoBehaviour
{
    public Renderer hexrend;
    public GameObject _targethexobject;
    void Start()
    {
        SelectObjects.terrainunit.Add(this);
        hexrend = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(2))
        {
            _targethexobject = null;
            hexrend.material.color = Color.white;
        }

    }

    void OnMouseEnter()
    {
        hexrend.material.color = new Color(0.7f, 0.6f, 0.6f, 0.9f);
    }

    void OnMouseExit()
    {
        if (_targethexobject != gameObject)
        {
            hexrend.material.color = Color.white;
        }

    }
    void OnMouseDown()
    {
        hexrend.material.color = new Color(0.5f, 0.3f, 0.3f, 0.9f);
        Debug.Log(gameObject.name);


    }
}