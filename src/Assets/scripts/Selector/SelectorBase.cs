using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class SelectorBase : MonoBehaviour
{
	private void OnMouseEnter()
	{
		MouseEnter();
	}

	private void OnMouseExit() 
	{
		MouseExit();
	}

	private void OnMouseOver()
	{
		var leftClick  = Input.GetMouseButtonDown(0);
		var rightClick = Input.GetMouseButtonDown(1);

		if(leftClick && !rightClick) MouseLeftDown();
		else if(!leftClick && rightClick) MouseRightDown();
		else if(leftClick && rightClick) DoubleRightDown();
	}

	public virtual void MouseEnter()
	{
		Debug.Log("Enter");
	}

	public virtual void MouseExit()
	{
		Debug.Log("Exit");
	}

	public virtual void MouseLeftDown()
	{
		Debug.Log("Left click");
	}

	public virtual void MouseRightDown()
	{
		Debug.Log("Right click");
	}

	public virtual void DoubleRightDown()
	{
		Debug.Log("Double click");
	}
}
