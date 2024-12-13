using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EconomicRepository : MonoBehaviour
{
    private Dictionary<long, EconomicItem> repository = new Dictionary<long, EconomicItem>()
    {
        { 0, new EconomicItem{ Name="Нефть", Value=10, Description="нефть, нужна для передвижения" } },
        { 1, new EconomicItem{ Name="Монеты", Value=20, Description="монеты, нужны для покупки юнитов" } },
         { 2, new EconomicItem{ Name="Валюта", Value=30, Description="валюты, нужны для ..." } }
    };

    public long Get(long id)
    {
        return repository[id].Value;
    }

    public void Add(long id, long el)
    {
        repository[id].Value += el;
    }
    public void Sub (long id, long el)
    { 
        repository[id].Value -= el;

    }
}
