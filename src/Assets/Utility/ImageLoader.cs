using UnityEditor;
using UnityEngine;

public class ImageLoader : EditorWindow
{
	private Texture2D loadedImage;

	private void OnGUI()
	{
		GUILayout.Label("Choose an image from outside the Assets folder", EditorStyles.boldLabel);

		if(GUILayout.Button("Load Image"))
		{
			LoadImageFromOutsideAssets();
		}

		if(loadedImage != null)
		{
			GUILayout.Label("Image Preview", EditorStyles.boldLabel);
			GUILayout.Box(loadedImage);
		}
	}

	private void LoadImageFromOutsideAssets()
	{
		// Используем OpenFilePanel для выбора изображения (работает на Windows, Mac, Linux)
		string path = EditorUtility.OpenFilePanel("Select an Image", "", "png,jpg,jpeg");

		if(!string.IsNullOrEmpty(path))
		{
			// Загружаем изображение
			byte[] fileData = System.IO.File.ReadAllBytes(path);
			loadedImage = new Texture2D(2, 2); // Массив для изображения
			loadedImage.LoadImage(fileData); // Загружаем изображение из байтов

			// Печатаем путь к файлу
			Debug.Log("Loaded image from: " + path);
		}
	}
}
