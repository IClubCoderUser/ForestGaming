using System.Collections.Generic;
using System.Helpers;

using UnityEngine;


public class SelectObjects : MonoBehaviour
{
	public static List<HexagonSelectHelper> terrainunit;

	private HexagonSelectHelper _terrain;

	public HexagonSelectHelper terrainunitSelected 
	{
		get => _terrain;
		set
		{
			
			if (_terrain == value) return;

			if (_terrain != null)
			{
				_terrain.GetComponent<Renderer>().material.color = Color.white;
			}

			_terrain = value;
			_terrain.GetComponent<Renderer>().material.color = new Color(0.7f, 0.4f, 0.4f, 0.9f);
		}
	}

	public static List<UnitSelectHelper> unit; // массив всех юнитов, которых мы можем выделить
	public static List<UnitSelectHelper> unitSelected; // массив выделенных юнитов

	public Renderer rend;
	public GUISkin skin;
	private Rect rect;
	private bool draw;
	private Vector2 startPos;
	private Vector2 endPos;
	public GameObject _targetobject;

	public Vector2 _diference;

	void Awake()
	{
		Initializer.Initialize(ref unit);
		Initializer.Initialize(ref unitSelected);
		Initializer.Initialize(ref terrainunit);
	}

	// проверка, добавлен объект или нет
	bool CheckUnit(GameObject unit)
	{
		bool result = false;
		foreach (var u in unitSelected)
		{
			if (u.gameObject == unit) result = true;
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
					else if (!CheckUnit(unit[j].gameObject))
					{
						unitSelected.Add(unit[j]);
					}
				}
			}
		}

		foreach(var selectUnit in unitSelected)
		{
			if(Camera.current != null)
			{
				var pos = Camera.current.WorldToScreenPoint(selectUnit.transform.position);
				pos = new Vector2(pos.x + 20, Screen.height - pos.y + 10);

				var rect = new Rect(pos, new Vector2(20, 20));

				var ost = selectUnit.Character.Speed - selectUnit.StepInStep;
				GUI.Box(rect, ost.ToString());

				if(selectUnit.Trace.Count > 0)
				{
					foreach(var item in selectUnit.Trace)
					{
						var pos2 = Camera.current.WorldToScreenPoint(item.transform.position);
						pos2 = new Vector2(pos2.x, Screen.height - pos2.y);
						var rect2 = new Rect(pos2, new Vector2(10, 10));
						GUI.Box(rect2, string.Empty);
					}
				}
			}
		}
	}

	public void Update()
	{
		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), Vector2.zero);

			if (hit.collider != null && hit.collider.tag == "Hexagon")
			{
				Debug.Log(hit.collider.transform.position);

				var wq = hit.transform.GetComponent<HexagonSelectHelper>();

				if (wq != null)
				{
					terrainunitSelected = wq;
				}
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), Vector2.zero);

			if (hit.collider != null && hit.collider.tag == "Hexagon")
			{
				Debug.Log(hit.collider.transform.position);
				foreach (var unit in unitSelected)
				{
					unit.TargetPosition = hit.collider.transform.position;
				}
			}
			else if (hit.collider != null && hit.collider.tag == "Player")
			{
				var target = hit.collider.gameObject.GetComponent<Character>();

				if (target != null)
				{
					foreach (var unit in unitSelected)
					{
						if (target.gameObject != unit.gameObject)
						{
							Debug.Log($"unit {unit.name} atack to {target.name}");

							unit.SetEnemy(target);
							//if(Vector3.Distance(target.transform.position, unit.transform.position) <= unit.Character.AttackCircles)
							//{
							//	unit.StepInStep = unit.Character.Speed;

							//	var attack = unit.Character.Attack;

							//	target.Damage(attack);
							//}
							//else
							//{
							//	unit.SetEnemy(target);
							//}
						}
					}
				}
			}
		}
	}
}
