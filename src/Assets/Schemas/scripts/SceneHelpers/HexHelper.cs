using UnityEngine;

public class HexHelper : MonoBehaviour
{
	[SerializeField]
	private float ScalerX = 1;

	[SerializeField]
	private float ScalerY = 1;


#if UNITY_EDITOR_64

	private void OnDrawGizmosSelected()
	{
		var resY = transform.position.y / ScalerY;
		var intResY = Mathf.Round(resY);


		if(intResY % 2 == 0)
		{
			var scalerX = ScalerX * 2;
			var resX = transform.position.x / scalerX;
			var intResX = Mathf.Round(resX);

			var pos = new Vector3(intResX * scalerX, intResY * ScalerY, 0);

			transform.position = pos;

			Gizmos.DrawWireSphere(pos, ScalerX);
		}
		else
		{
			var scalerX = ScalerX * 2;
			var resX = (transform.position.x + ScalerX) / scalerX;
			var intResX = Mathf.Round(resX);

			var pos = new Vector3(intResX * scalerX - ScalerX, intResY * ScalerY, 0);

			transform.position = pos;

			Gizmos.DrawWireSphere(pos, ScalerX);
		}
	}

#endif
}
