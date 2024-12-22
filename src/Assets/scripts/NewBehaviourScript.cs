using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField] private GameObject[] _array;


  

    // Start is called before the first frame update
    void Start()
    {
        _object = gameObject;
        _array = GameObject.FindGameObjectsWithTag("cas");

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var a in _array)
        {
            Vector3 direct = Vector3.zero;
            foreach (var target in _array)
            {
                var dir = target.transform.position - a.transform.position;
                direct += dir;
            }

            a.transform.position += direct * Time.deltaTime;
            
        }

    }
}
