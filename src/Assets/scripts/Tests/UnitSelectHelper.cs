using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectHelper : MonoBehaviour
{
    [SerializeField]
    private bool isMoving;
    private Vector3 _target;
    public float speed = 10f;

    public Vector3 targetPosition
    {
        get => _target;
        set
        { 
            _target = value;
            isMoving = true;
        }
    }
    

    // Start is called before the first frame update
    public void Start()
    {
        SelectObjects.unit.Add(this);
    }

    public void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }

    }
}