using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DebugCOnsole : MonoBehaviour
{
    [SerializeField]
    private EconomicRepository Repository;

    [SerializeField]
    private Text Text;

    public long Id;

    public long Val = 15;

    // Update is called once per frame
    void Update()
    {
        Text.text = Repository.Get(Id).ToString();
    }

    public void Sub()
    {
        Repository.Sub(Id, Val);
    }
}
