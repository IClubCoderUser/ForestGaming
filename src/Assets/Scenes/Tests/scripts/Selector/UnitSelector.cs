// Change the mesh color in response to mouse actions.

using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class UnitSelector : MonoBehaviour
{
    public Renderer rend;
    public GameObject _targetobject;
    public Vector2 _diference;

    private bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 10f;

    public void FixedUpdate()
    {
        if (Input.GetMouseButton(1) && _targetobject != null)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }

        if (Input.GetMouseButton(2))
        {
            _targetobject = null;
            rend.material.color = Color.white;
        }
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void OnMouseEnter()
    {
        rend.material.color = new Color(0.3f, 0.2f, 0.2f, 0.9f);
    }

    void OnMouseExit()
    {
        if (_targetobject != gameObject)
        {
            rend.material.color = Color.white;
        }
            
    }
    void OnMouseDown()
    {
        rend.material.color = new Color(0.5f, 0.3f, 0.3f, 0.9f);
        Debug.Log(gameObject.name);
        _targetobject = gameObject;
        
    }
}