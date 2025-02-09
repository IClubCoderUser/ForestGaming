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
    public float defCurrent;

    public SpriteRenderer hpbar;
    public SpriteRenderer defbar;

    // Start is called before the first frame update
    void Start()
    {
        hpCurrernt = Hp;
        defCurrent = Defense;
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
        if (defCurrent > 1)
        {
            defCurrent -= Damage;
        }
        else 
        {
            hpCurrernt -= Damage;
        }

        if (hpbar != null)
        {
            var x = hpCurrernt / Hp;
            hpbar.size = new Vector2(x, 0.98f);
        }
        if (defbar != null)
        {
            var x = defCurrent / Defense;
            defbar.size = new Vector2(x, 0.98f);
        }

        if (hpCurrernt < 1)
        {
            Destroy(gameObject);
        }
        if (defCurrent < 0)
        {
            defCurrent = 0;
        }
    }
}
