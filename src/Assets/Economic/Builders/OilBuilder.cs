using UnityEngine;

public class OilBuilder : ItemResources
{
	public int Value = 20;

	public override int Output => Value;

	public override GameObject Reference => gameObject;

	public override long ResourceId => 0;
}
