using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVTOMATIONOPENDOOR : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.F)) ;
        { }
        _animator.SetBool("Door", !_animator.GetBool("Door"));
    }
}