using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private bool _isActive;
    public GameObject button;

    private void Start()
    {
        button.SetActive(false);
    }
    public void FixedUpdate()
    {
        if (_isActive != SelectObjects.ActiveUnitSelect)
        {
            button.SetActive(SelectObjects.ActiveUnitSelect);
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