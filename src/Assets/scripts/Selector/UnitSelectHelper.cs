using Assets.scripts.Selector;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class UnitSelectHelper : MonoBehaviour
{
	[SerializeField]
	private bool isMoving;
	private Vector3 _target;
	public float speed = 10f;

	public int StepInStep = 0;

	public Character Character { get; private set; }
	public HexHelper HexHelper;

	public List<HexHelper> Trace;

	public Vector3 targetPosition
	{
		get => _target;
		set
		{ 
			if(StepInStep < Character.Speed)
			{
				_target = value;
				isMoving = true;
				Trace = OptimizatorMinDistance.Optimaze(HexHelper, value, Character.Speed - StepInStep, out int step);
				StepInStep += step;
			}
		}
	}
	

	// Start is called before the first frame update
	public void Start()
	{
		SelectObjects.unit.Add(this);

		Character = GetComponent<Character>();

		if(HexHelper)
		{
			transform.position = HexHelper.transform.position;
		}
		else
		{
			Debug.LogWarning($"Юнит {gameObject.name} не привязан к поверхности.");
		}
	}

	public void FixedUpdate()
	{
		if (isMoving)
		{
			if(Trace == null)
			{
				isMoving = false;
				return;
			}

			if(Trace.Count > 0)
			{
				transform.position = Vector2.MoveTowards(transform.position, Trace[0].transform.position, Time.fixedDeltaTime * speed);
				if(transform.position == Trace[0].transform.position)
				{
					HexHelper = Trace[0];
					Trace.RemoveAt(0);
				}
			}
			//transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
			//if (transform.position == targetPosition)
			//{
			//	isMoving = false;
			//}
		}
	}

	private void OnGUI()
	{
		//if(Camera.current != null)
		//{
		//	var pos = Camera.current.WorldToScreenPoint(transform.position);
		//	pos = new Vector2(pos.x + 20, Screen.height - pos.y + 10);

		//	var rect = new Rect(pos, new Vector2(20, 20));
		//	GUI.Box(rect, (Character.Speed - StepInStep).ToString());
		//}
	}

	[ContextMenu("SetOrigin")]
	public void SetOrigin()
	{
		if(HexHelper != null) transform.position = HexHelper.transform.position;
	}

	private void OnDestroy()
	{
		SelectObjects.unit.Remove(this);
	}
}