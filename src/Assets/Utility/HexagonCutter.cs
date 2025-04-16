using UnityEngine;

public static class HexagonCutter
{
	/// <summary>
	/// Вырезает шестиугольник из текстуры.
	/// </summary>
	/// <param name="texture">Исходная текстура.</param>
	/// <param name="center">Центр шестиугольника (в пикселях).</param>
	/// <param name="size">Размер шестиугольника (радиус, от центра до вершины).</param>
	/// <returns>Текстура с вырезанным шестиугольником.</returns>
	public static Texture2D CutHexagon(Texture2D texture, Vector2 center, int size)
	{
		// Размер выходного изображения
		int width = size * 2;
		int height = size * 2;

		// Создаём новый массив пикселей для изображения
		Color[] pixels = new Color[width * height];

		// Получаем массив пикселей исходной текстуры
		Color[] originalPixels = texture.GetPixels();

		// Коэффициенты для вычисления углов шестиугольника
		float angleStep = Mathf.PI / 3f;
		Vector2[] hexagonPoints = new Vector2[6];
		for(int i = 0; i < 6; i++)
		{
			hexagonPoints[i] = new Vector2(
				center.x + size * Mathf.Cos(i * angleStep),
				center.y + size * Mathf.Sin(i * angleStep)
			);
		}

		// Заполняем пиксели для нового изображения с шестиугольной маской
		for(int y = 0; y < height; y++)
		{
			for(int x = 0; x < width; x++)
			{
				// Проверка, лежит ли текущий пиксель внутри шестиугольника
				if(IsPointInHexagon(new Vector2(x, y), hexagonPoints))
				{
					// Переводим координаты в координаты исходной текстуры
					Vector2 originalCoord = new Vector2(center.x + (x - size), center.y + (y - size));

					// Обрезаем, чтобы не выходить за пределы текстуры
					originalCoord.x = Mathf.Clamp(originalCoord.x, 0, texture.width - 1);
					originalCoord.y = Mathf.Clamp(originalCoord.y, 0, texture.height - 1);

					// Сохраняем пиксель в новый массив
					pixels[y * width + x] = originalPixels[(int)(originalCoord.y) * texture.width + (int)(originalCoord.x)];
				}
				else
				{
					pixels[y * width + x] = new Color(0, 0, 0, 0); // Прозрачный пиксель
				}
			}
		}

		// Создаём новую текстуру и применяем пиксели
		Texture2D resultTexture = new Texture2D(width, height);
		resultTexture.SetPixels(pixels);
		resultTexture.Apply();

		return resultTexture;
	}

	/// <summary>
	/// Проверяет, лежит ли точка внутри шестиугольника.
	/// </summary>
	/// <param name="point">Точка для проверки.</param>
	/// <param name="hexagonPoints">Массив точек шестиугольника.</param>
	/// <returns>True, если точка внутри шестиугольника, иначе false.</returns>
	private static bool IsPointInHexagon(Vector2 point, Vector2[] hexagonPoints)
	{
		int i, j;
		bool inside = false;
		for(i = 0, j = 5; i < 6; j = i++)
		{
			if(((hexagonPoints[i].y > point.y) != (hexagonPoints[j].y > point.y)) &&
				(point.x < (hexagonPoints[j].x - hexagonPoints[i].x) * (point.y - hexagonPoints[i].y) / (hexagonPoints[j].y - hexagonPoints[i].y) + hexagonPoints[i].x))
			{
				inside = !inside;
			}
		}
		return inside;
	}
}
