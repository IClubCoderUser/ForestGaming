using UnityEngine;

public class MoneyBuilder : ItemResources
{
	public int Value = 10;

	public override int Output => Value;

	public override GameObject Reference => gameObject;

	public override long ResourceId => 1;
}
