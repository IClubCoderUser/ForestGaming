using Assets.Economic;
using UnityEngine;

public class AIUnitController : IController
{
	public override int Order => OrderUpdateController.CurrentUpdate;

	public override bool Init()
	{
		var my = GameObject.FindObjectsOfType<AIUnit>();

		foreach(var m in my)
		{ 
			m.Init();
		}

		return true;
	}

	public override void StateUpdate()
	{
		var my = GameObject.FindObjectsOfType<AIUnit>();

		foreach(var m in my)
		{
			m.Step();
		}
	}
}
