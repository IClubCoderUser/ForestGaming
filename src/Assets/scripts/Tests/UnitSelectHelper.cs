using UnityEngine;

[RequireComponent(typeof(Character))]
public class UnitSelectHelper : MonoBehaviour
{
    [SerializeField]
    private bool isMoving;
    private Vector3 _target;
    public float speed = 10f;

    public Character Character { get; private set; }

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

        Character = GetComponent<Character>();
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