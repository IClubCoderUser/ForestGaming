using Assets.Economic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class MergeStateController : MonoBehaviour
{
	[SerializeField] private IController[] Controllers;

	private int StateCount;
	private SynchronizationContext syncContext;

	private void Start()
	{
		syncContext = SynchronizationContext.Current;

		foreach(var comp in Controllers)
		{
			comp.Init();
		}
	}


	[ContextMenu("Update")]
	public void UpdateControllers()
	{
		Controllers = GameObject.FindObjectsOfType<IController>().OrderBy(x=>x.Order).ToArray();

		StateCount = Controllers.Length;
	}

	public void UpdateState()
	{
		syncContext.Post(x =>
		{
			foreach(var comp in Controllers)
			{
				comp.StateUpdate();
			}
		}, null);
	}
}
