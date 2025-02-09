using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Pole : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private GameObject[] _planets;
    [SerializeField] private GameObject[] _whiteholes;
    public float _speedtransform = 1 ;

    // Start is called before the first frame update
    void Start()
    {
        _object = gameObject;

        _whiteholes = GameObject.FindGameObjectsWithTag("WhiteHole");

        _planets = GameObject.FindGameObjectsWithTag("Planet");


    }

    // Update is called once per frame
    void Update()
    {
        foreach (var planet in _planets)
        {
            Vector3 direct = Vector3.zero;

            foreach (var target in _planets)
            {
                var dir = target.transform.position - planet.transform.position;
                direct += dir;
            }

            foreach (var target in _whiteholes)
            {
                var dir = target.transform.position - planet.transform.position;
                direct += dir;
            }

            planet.transform.position += direct * Time.deltaTime * _speedtransform;

        }
    }
}
