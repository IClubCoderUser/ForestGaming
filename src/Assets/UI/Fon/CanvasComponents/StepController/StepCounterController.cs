using Assets.Economic;

using UnityEngine;
using UnityEngine.UI;

public class StepCounterController : IController
{
	public override int Order => OrderUpdateController.PostUpdate;

	public Text Step;

	public int Counter
	{
		get => Step?.text.ToInt32() ?? int.MinValue;
		set
		{
			if(Step != null)
			{
				Step.text = $"{value}";
			}
		}
	}

	public override bool Init()
	{
		if(Step == null)
		{
			Step = GetComponent<Text>() ?? GameObject.Find("StepCounterView").GetComponent<Text>();
		}

		Counter = 0;

		return true;
	}

	public override void StateUpdate()
	{
		Counter++;
	}
}
