using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class ioadiocatioon : MonoBehaviour
{
    [SerializeField]
    [Header("Путь")]
    public string _imageName;

    [SerializeField]
    [Header("Ширина")]
    public int _width;

    [SerializeField]
    [Header("Высота")]
    public int _height;

    public GameObject[] _presets;

    [ContextMenu("generate")]
    public void generate()
    {
        if (string.IsNullOrEmpty(_imageName))
        {
            Debug.LogError("нет ссылки на каритинку");
            return;
        }
        if (!File.Exists(_imageName))
        {
            Debug.LogError("не верный путь до изображения");
            return;
        }

        if (_width <= 0 || _height <= 0)
        {
            Debug.LogError("ты чё, офигел");
            return;
        }

        //for (int i = 0; i < 10; i++)
        //    for (int j = 0; j < 10; j++)
        //    {
        //        var g = GameObject.Instantiate(_preset) as GameObject;
        //        g.name = $"{i} : {j}";

        //        HexHelper.SetPosition(g, i, j, 2, 3);
        //    }

        using (var stream = File.Open(_imageName, FileMode.Open, FileAccess.Read))
        using (var mem = new MemoryStream())
        {
            stream.CopyTo(mem);

            var texture = new Texture2D(_width, _height);
            texture.LoadImage(mem.ToArray());

            Generate(texture);

            //CreateOnScene(texture);
        }
    }
             
    private void Generate(Texture2D texture)
    {
        var presets = _presets.Select(x => x.GetComponent<HexHelper>());

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                var pixel = texture.GetPixel(i, j);

                var min = presets.Min(x => Mathf.Sqrt(Mathf.Pow(x._color.r - pixel.r, 2) + Mathf.Pow(x._color.g - pixel.g, 2) + Mathf.Pow(x._color.b - pixel.b, 2)));
                var item = presets.FirstOrDefault(x => Mathf.Sqrt(Mathf.Pow(x._color.r - pixel.r, 2) + Mathf.Pow(x._color.g - pixel.g, 2) + Mathf.Pow(x._color.b - pixel.b, 2)) == min);

                var obj = _presets.FirstOrDefault(x => x.GetComponent<HexHelper>() == item);

                var g = GameObject.Instantiate(obj) as GameObject;
                g.name = $"{i} : {j}";

                HexHelper.SetPosition(g, i, j, 2, 3);
            }
        }
    }

    private void CreateOnScene(Texture2D texture)
    {
        var sprite = Sprite.Create(texture, new Rect(0, 0, _width, _height), Vector2.one);
        sprite.name = Path.GetFileName(_imageName);

        var obj = new GameObject("-----");
        obj.transform.position = new Vector2(0, 0);

        var q = obj.AddComponent<SpriteRenderer>();
        q.name = Path.GetFileName(_imageName);
        q.sprite = sprite;
    }
}
