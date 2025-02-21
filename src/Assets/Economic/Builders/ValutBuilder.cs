using UnityEngine;

public class ValutBuilder : ItemResources
{
	public int Value = 1;

	public override int Output => Value;

	public override GameObject Reference => gameObject;

	public override long ResourceId => 2;
}