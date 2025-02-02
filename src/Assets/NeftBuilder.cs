using System.Collections;
using UnityEngine;

public class NeftBuilder : ItemResources
{
    public int Value = 20;

    public override int Output => Value;

    public override GameObject Reference => gameObject;

    public override long ResourceId => 0;
}

public class MoneyBuilder : ItemResources
{
    public int Value = 10;

    public override int Output => Value;

    public override GameObject Reference => gameObject;

    public override long ResourceId => 1;
}
public class ValutBuilder : ItemResources
{
    public int Value = 1;

    public override int Output => Value;

    public override GameObject Reference => gameObject;

    public override long ResourceId => 2;
}