using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        SelectObjects.unit.Add(gameObject);
    }

}