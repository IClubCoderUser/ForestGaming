using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectObjects : MonoBehaviour
{

    public static List<GameObject> unit; // массив всех юнитов, которых мы можем выделить
    public static List<GameObject> unitSelected; // массив выделенных юнитов

    public Renderer rend;
    public GUISkin skin;
    private Rect rect;
    private bool draw;
    private Vector2 startPos;
    private Vector2 endPos;
    public GameObject _targetobject;

    public Vector2 _diference;

    private bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 10f;


    void Awake()
    {
        unit = new List<GameObject>();
        unitSelected = new List<GameObject>();
    }

    // проверка, добавлен объект или нет
    bool CheckUnit(GameObject unit)
    {
        bool result = false;
        foreach (GameObject u in unitSelected)
        {
            if (u == unit) result = true;
        }
        return result;
    }

    void Select()
    {
        if (unitSelected.Count > 0)
        {
            for (int j = 0; j < unitSelected.Count; j++)
            {
                // делаем что-либо с выделенными объектами
                unitSelected[j].GetComponent<Renderer>().material.color = new Color(0.7f, 0.4f, 0.4f, 0.9f);
                _targetobject = unitSelected[j];

            }
        }
    }

    void Deselect()
    {
        if (unitSelected.Count > 0)
        {
            for (int j = 0; j < unitSelected.Count; j++)
            {
                // отменяем то, что делали с объектоми
                unitSelected[j].GetComponent<Renderer>().material.color = Color.white;
                

            }
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.depth = 99;

        if (Input.GetMouseButtonDown(0))
        {
            Deselect();
            startPos = Input.mousePosition;
            draw = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            draw = false;
            Select();
        }

        if (draw)
        {
            unitSelected.Clear();
            endPos = Input.mousePosition;
            if (startPos == endPos) return;

            rect = new Rect(Mathf.Min(endPos.x, startPos.x),
                            Screen.height - Mathf.Max(endPos.y, startPos.y),
                            Mathf.Max(endPos.x, startPos.x) - Mathf.Min(endPos.x, startPos.x),
                            Mathf.Max(endPos.y, startPos.y) - Mathf.Min(endPos.y, startPos.y)
                            );

            GUI.Box(rect, "");

            for (int j = 0; j < unit.Count; j++)
            {
                // трансформируем позицию объекта из мирового пространства, в пространство экрана
                Vector2 tmp = new Vector2(Camera.main.WorldToScreenPoint(unit[j].transform.position).x, Screen.height - Camera.main.WorldToScreenPoint(unit[j].transform.position).y);

                if (rect.Contains(tmp)) // проверка, находится-ли текущий объект в рамке
                {
                    if (unitSelected.Count == 0)
                    {
                        unitSelected.Add(unit[j]);
                    }
                    else if (!CheckUnit(unit[j]))
                    {
                        unitSelected.Add(unit[j]);
                    }
                }
            }
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetMouseButton(1) && _targetobject == gameObject)
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

        //if (Input.GetMouseButton(2))
        //{
        //    _targetobject = null;
        //    rend.material.color = Color.white;

        //}
    }
}