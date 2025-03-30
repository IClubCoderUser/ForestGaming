using System.Linq;
using UnityEngine;

public class HexHelper : MonoBehaviour
{
	[SerializeField]
	private float ScalerX = 1;

	[SerializeField]
	private float ScalerY = 1;

	public HexHelper[] Hexs;

	public Color _color;

    public static void SetPosition(GameObject obj, int x, int y, float scaleX = 2, float scaleY = 3, float sx = 4, float sy=3)
    {
        var resY = y * sy / scaleY;
        var intResY = Mathf.Round(resY);

        if (intResY % 2 == 0)
        {
            var scalerX = scaleX * 2;
            var resX = x * sx / scalerX;
            var intResX = Mathf.Round(resX);

            var pos = new Vector3(intResX * scalerX, intResY * scaleY, 0);

            obj.transform.position = pos;
        }
        else
        {
            var scalerX = scaleX * 2;
            var resX = (x * sx + scaleX + 0.01f) / scalerX;
            var intResX = Mathf.Round(resX);

            var pos = new Vector3(intResX * scalerX - scaleX, intResY * scaleY, 0);

            obj.transform.position = pos;
        }
    }


#if UNITY_EDITOR_64



    private void OnDrawGizmosSelected()
	{
		var resY = transform.position.y / ScalerY;
		var intResY = Mathf.Round(resY);

		Gizmos.color = Color.white;
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

		foreach(var item in Hexs)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, item.transform.position);
		}
	}

	[ContextMenu("Connect")]
	public void Connect()
	{
		Hexs = GameObject.FindObjectsOfType<HexHelper>().Where(x=>
		{
			var dist = Vector2.Distance(this.transform.position, x.transform.position);

			return dist <= 4 && dist != 0;
		}).ToArray();
	}

#endif
}
