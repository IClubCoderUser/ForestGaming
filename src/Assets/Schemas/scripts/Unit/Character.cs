using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography;
using UnityEngine;


public class Character : MonoBehaviour
{
    /// <summary>��� ���� �� ���������.</summary>
    public float Hp = 150;
    /// <summary>��� ����� ���������.</summary>
    public float Defense = 120;
    /// <summary>��� ����� ���������.</summary>
    public float Attack = 60;
    /// <summary>��� ��������� �������� ����� ��������� �� ���.</summary>
    public float MoveCirclesMany = 3;
    /// <summary>��� ������������ ��������� ���������.</summary>
    public float AttackCircles = 8;
    public float Crit = 90;
    public float hpCurrernt;

    // Start is called before the first frame update
    void Start()
    {
        hpCurrernt = Hp;
    }


    // Update is called once per frame
    void Update()
    {

    }

    [UnityEngine.ContextMenu("damagetest")]
    private void damagetest()
    {
      Damage(50);
    }

    [UnityEngine.ContextMenu("healtest")]
    private void heal()
    {
         heal(50);
    }

    private void heal(float value)
    {

    }

    public void Damage(float Damage)
    {
        if (Defense > 1)
        {
            Defense -= Damage;
        }
        if (Defense < 1)
        {
            hpCurrernt -= Damage;
        }

        if (hpCurrernt < 1)
        {
 
            Destroy(gameObject);
        }
    }
}
