using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.Networking.Types;

public class HexagonCutterEditor : EditorWindow
{
	private Texture2D loadedImage;
	private Texture2D croppedImage;
	private Texture2D rescaleImage;

	private string loadedImagePath;
	private Vector2 center = new Vector2(100, 100); 
	private float hexRadius = 1; 
	private Color hexColor = Color.red;
	private bool auto = false;

	private Vector2 _oldCenter;

	[MenuItem("Tools/Hexagon Cutter Editor")]
	public static void ShowWindow()
	{
		GetWindow(typeof(HexagonCutterEditor), false, "Hexagon Cutter");
	}

	private void OnGUI()
	{
		GUILayout.Label("Hexagon Cutter", EditorStyles.boldLabel);

		if(GUILayout.Button("Load Image from Outside Assets"))
		{
			LoadImageFromOutsideAssets();
		}

		if(GUILayout.Button("Crop Hexagon"))
		{
			CropHexagonFromImage();
		}

		GUILayout.BeginHorizontal();

		if(rescaleImage != null)
		{
			GUILayout.BeginVertical();
			GUILayout.Label("Loaded Image Preview", EditorStyles.boldLabel);
			GUILayout.Box(rescaleImage, GUILayout.Width(200), GUILayout.Height(200));
			GUILayout.EndVertical();
		}

		if(croppedImage != null)
		{
			GUILayout.BeginVertical();
			GUILayout.Label("Cropped Hexagon", EditorStyles.boldLabel);
			GUILayout.Box(croppedImage, GUILayout.Width(200), GUILayout.Height(200));
			

			if(_oldCenter != center)
			{
				CropHexagonFromImage();
				_oldCenter = center;
			}
			GUILayout.EndVertical();
		}

		GUILayout.EndHorizontal();

		if(croppedImage != null && GUILayout.Button("Save Hexagon"))
		{
			SaveHexagon();
		}

		hexRadius = EditorGUILayout.Slider("Hexagon Radius", hexRadius, 0.2f, 2f);
		auto      = EditorGUILayout.Toggle("Auto", auto);
		center    = EditorGUILayout.Vector2Field("Center", center);
	}

	private void LoadImageFromOutsideAssets()
	{
		string path = EditorUtility.OpenFilePanel("Select an Image", "", "png,jpg,jpeg");

		if(!string.IsNullOrEmpty(path))
		{
			byte[] fileData = File.ReadAllBytes(path);
			loadedImage = new Texture2D(2, 2);
			loadedImage.LoadImage(fileData);

			rescaleImage = loadedImage;

			loadedImagePath = path;
			Debug.Log("Image loaded from: " + loadedImagePath);
		}
		else
		{
			Debug.LogWarning("No image selected.");
		}
	}

	public Texture2D CloneTexture(Texture2D original)
	{
		// Создаём новый объект Texture2D с теми же размерами и форматом
		Texture2D clone = new Texture2D(original.width, original.height, original.format, false);

		// Копируем все пиксели из оригинальной текстуры
		clone.SetPixels(original.GetPixels());

		// Применяем изменения (инициализируем текстуру)
		clone.Apply();

		return clone;
	}

	private void CropHexagonFromImage()
	{
		if(loadedImage == null)
		{
			Debug.LogWarning("No image loaded.");
			return;
		}

		croppedImage = new Texture2D(200, 200);
		Color[] pixels = new Color[200 * 200];

		if(auto)
		{
			center = GetAutoCenter(rescaleImage);
		}

		Vector2[] hexagonPoints = CreateHexagon(center, 200, 200);
		for(int y = 0; y < 200; y++)
		{
			for(int x = 0; x < 200; x++)
			{
				Vector2 point = new Vector2(
					center.x - 100 + x,
					center.y - 100 + y);

				if(PointInHexagon(point, hexagonPoints))
				{
					Color color = rescaleImage.GetPixelBilinear(point.x / rescaleImage.width, point.y / rescaleImage.height);
					pixels[y * 200 + x] = color;
				}
				else
				{
					pixels[y * 200 + x] = Color.clear; 
				}
			}
		}

		croppedImage.SetPixels(pixels);
		croppedImage.Apply();
	}

	public static Vector2 GetAutoCenter(Texture2D bmp)
	{
		long totalX = 0, totalY = 0, totalWeight = 0;

		for(int y = 0; y < bmp.height; y++)
		{
			for(int x = 0; x < bmp.width; x++)
			{
				Color c = bmp.GetPixel(x, y);
				int brightness = (int)(0.299 * c.r * 255 + 0.587 * c.g * 255 + 0.114 * c.b * 255);

				totalX += x * brightness;
				totalY += y * brightness;
				totalWeight += brightness;
			}
		}

		if(totalWeight == 0)
			return new Vector2(bmp.width / 2, bmp.height / 2);

		return new Vector2((int)(totalX / totalWeight), (int)(totalY / totalWeight));
	}

	private bool PointInHexagon(Vector2 point, Vector2[] hexagon)
	{
		int i, j;
		bool inside = false;

		for(i = 0, j = hexagon.Length - 1; i < hexagon.Length; j = i++)
		{
			if(((hexagon[i].y > point.y) != (hexagon[j].y > point.y)) &&
				(point.x < (hexagon[j].x - hexagon[i].x) * (point.y - hexagon[i].y) / (hexagon[j].y - hexagon[i].y) + hexagon[i].x))
			{
				inside = !inside;
			}
		}
		return inside;
	}

	public static Vector2[] CreateHexagon(Vector2 center, float width, float height)
	{
		Vector2[] points = new Vector2[6];
		float w = width / 2f;
		float h = height / 2f;

		points[0] = new Vector2((int)(center.x), (int)(center.    y - h));      
		points[1] = new Vector2((int)(center.x + w), (int)(center.y - h / 2));
		points[2] = new Vector2((int)(center.x + w), (int)(center.y + h / 2));
		points[3] = new Vector2((int)(center.x), (int)(center.    y + h));      
		points[4] = new Vector2((int)(center.x - w), (int)(center.y + h / 2));
		points[5] = new Vector2((int)(center.x - w), (int)(center.y - h / 2));

		return points;
	}

	private void SaveHexagon()
	{
		if(croppedImage == null)
		{
			Debug.LogWarning("No cropped hexagon to save.");
			return;
		}

		string savePath = EditorUtility.SaveFilePanel("Save Hexagon", "", "hexagon_image", "png");

		if(!string.IsNullOrEmpty(savePath))
		{
			byte[] imageBytes = croppedImage.EncodeToPNG();
			File.WriteAllBytes(savePath, imageBytes);
			Debug.Log("Hexagon saved to: " + savePath);
		}
	}
}
