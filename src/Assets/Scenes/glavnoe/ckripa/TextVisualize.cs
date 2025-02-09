using UnityEngine;
using UnityEngine.UI;

public class TextVisualize : MonoBehaviour
{
    public Text _textNeft;
    public Text _textMoney;
    public Text _textRes;
    
    public EconomicRepository _repository;

    [SerializeField] private string _name;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        var meta = _repository.GetMetaDataById(0);
        _textNeft.text = $"{meta.Name}: {meta.Value}";

        var meta2 = _repository.GetMetaDataById(1);
        _textMoney.text = $"{meta2.Name}: {meta2.Value}";

        var meta3 = _repository.GetMetaDataById(2);
        _textRes.text = $"{meta3.Name}: {meta3.Value}";
    }
}
