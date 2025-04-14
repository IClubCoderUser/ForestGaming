using UnityEngine;

public class SelectObjectWatcherScript : MonoBehaviour
{
	[SerializeField] private bool _isActive;
	[SerializeField] private GameObject _target;

	private void Start()
	{
		_target.SetActive(false);
	}

	public void FixedUpdate()
	{
		if(_isActive != SelectObjects.ActiveUnitSelect)
		{
			_target.SetActive(SelectObjects.ActiveUnitSelect);
			_isActive = SelectObjects.ActiveUnitSelect;
		}
	}
	//public void ChangeInfoScene()
	//{
	//    SceneManager.LoadScene("InformationForUnits", LoadSceneMode.Additive);
	//}

	//public void ChangeGameScene()
	//{
	//    SceneManager.UnloadSceneAsync("InformationForUnits");
	//}
}
// ExtandedUnit
// InformationForUnits