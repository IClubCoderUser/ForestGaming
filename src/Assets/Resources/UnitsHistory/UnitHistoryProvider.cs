using Assets.scripts.Framework;

using UnityEngine;

public class UnitHistoryProvider : MonoBehaviour
{
	private ResourceProvider<Object> _historyProvider;

	[SerializeField] private string _folder;

	private void Start()
	{
		_historyProvider = new ResourceProvider<Object>(_folder);
	}

	public string LoadByName(string path)
	{ 
		return _historyProvider.LoadByName(path).ToString();
	}
}
