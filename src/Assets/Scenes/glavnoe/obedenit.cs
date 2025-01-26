using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class obedenit : MonoBehaviour
{

    private EconomicRepository a;
 
    


    public void NextStep()
    {
        //var allNeft = GameObject.FindGameObjectsWithTag("neft");
        //a.AddById(0, allNeft.Length * 10);
        var arrayNeft = GameObject.FindObjectsByType<NeftBuilder>(FindObjectsSortMode.None);
        a.AddById(0, (long)arrayNeft.Sum(x=>x.Value));

        //var allMoney = GameObject.FindGameObjectsWithTag("money");
        //a.AddById(1, allMoney.Length * 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<EconomicRepository>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
