using UnityEngine;

public class TerrainImpl : SelectorBase
{
	[Header("Параметры области")]
	[SerializeField] private TerrainParameters _parameters;
	[SerializeField] private SpriteRenderer _sprite;

	[Header("Цвет выделения")]
	[SerializeField] private Color _higlight = Color.gray;

	public override void MouseLeftDown()
	{
		Debug.Log($"{_parameters?.DisplayName ?? "no name"}");
	}

	public override void MouseEnter()
	{
		if(_sprite != null)
		{
			_sprite.color = _higlight;
		}
	}

	public override void MouseExit()
	{
		if(_sprite != null)
		{
			_sprite.color = Color.white;
		}
	}
}
