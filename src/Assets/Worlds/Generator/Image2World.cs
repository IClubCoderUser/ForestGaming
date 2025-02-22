using UnityEngine;

/// <summary>Генератор миров.</summary>
public class Image2World : MonoBehaviour
{
	public string PathImage;
	public int Width;
	public int Height;

	[ContextMenu("Image2World")]
	public void Generate()
	{
		var image = new Texture2D(Width, Height);

		var data = System.IO.File.ReadAllBytes(PathImage);

		image.LoadImage(data);

		for(int i = 0; i < image.width - 2; i++)
		{
			for(int j = 0; j < image.height - 2; j++)
			{
				var color00 = image.GetPixel(i, j);
				var color01 = image.GetPixel(i + 1, j);
				var color02 = image.GetPixel(i + 2, j);

				var color10 = image.GetPixel(i, j + 1);
				var color11 = image.GetPixel(i + 1, j + 1);
				var color12 = image.GetPixel(i + 2, j + 1);

				var color20 = image.GetPixel(i, j + 2);
				var color21 = image.GetPixel(i + 1, j + 2);
				var color22 = image.GetPixel(i + 2, j + 2);

				var l1 = Color.Lerp(color00, color01, 2);
				var l2 = Color.Lerp(color01, color02, 2);
				var l3 = color12;
				var l4 = Color.Lerp(color22, color21, 2);
				var l5 = Color.Lerp(color20, color21, 2);
				var l6 = color10;
			}
		}
	}
}
