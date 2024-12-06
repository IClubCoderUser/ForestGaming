using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;

      void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) 
        {
            _animator.SetBool("Door", !_animator.GetBool("Door"));
        }
    }
}
