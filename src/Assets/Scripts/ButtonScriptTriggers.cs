using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptTriggers : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void FixedUpdate()
    {
         if (Input.GetKey(KeyCode.F))
         {
            _animator.SetBool("OpenControl", !_animator.GetBool("OpenControl"));
         }
    }
}
