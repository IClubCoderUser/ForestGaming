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
    public float speed = 1f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
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
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void FixedUpdate()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(diference);
    }
    void OnMouseEnter()
    {
        rend.material.color = new Color(0.9f, 0.4f, 0.4f, 0.8f);
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        _targetobject = gameObject;
        
    }
}