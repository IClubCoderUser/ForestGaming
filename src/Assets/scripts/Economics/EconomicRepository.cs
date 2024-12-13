using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EconomicRepository : MonoBehaviour
{
    private Dictionary<long, EconomicItem> repository = new Dictionary<long, EconomicItem>()
    {
        { 0, new EconomicItem{ Name="�����", Value=10, Description="�����, ����� ��� ������������" } },
        { 1, new EconomicItem{ Name="������", Value=20, Description="������, ����� ��� ������� ������" } },
         { 2, new EconomicItem{ Name="������", Value=30, Description="������, ����� ��� ..." } }
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
