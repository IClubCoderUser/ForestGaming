using System.Linq;
using UnityEngine;

public class AIUnit : MonoBehaviour
{
	private UnitSelectHelper Unit;

	public void Init()
	{
		Unit = GetComponent<UnitSelectHelper>();
	}

	public void Step()
	{
		var characjters = GameObject.FindObjectsOfType<Character>().Where(x=>transform != x.transform).FirstOrDefault();

		if(characjters != null)
		{
			Unit.SetEnemy(characjters);
		}
	}
}
