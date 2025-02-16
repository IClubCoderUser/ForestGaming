using Assets.UI.Flags;
using UnityEngine;

public class FlagObject : MonoBehaviour
{
	private FlagsEnum _country;
	public SpriteRenderer SpriteRenderer;

	public FlagsEnum Country
	{
		get => _country;
		set
		{
			_country = value;
			var str = _country.ToString();
			SpriteRenderer.sprite = FlagsProvider.Load(str);
		}
	}
}
