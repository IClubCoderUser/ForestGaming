using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class obedenit : MonoBehaviour
{
    public long neft;
    public long monet;
    public long valut;
    private EconomicRepository a;
    public repositoriValut repositoriValut;

    public void NextStep()
    {
        try
        {
            neft = repositoriValut.Fetch(resourceId: 0).Count();
            monet = repositoriValut.Fetch(resourceId: 1).Count();
            valut = repositoriValut.Fetch(resourceId: 2).Count();
        }
        catch
        {
            Debug.LogError(this.name);
            throw;
        }
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
