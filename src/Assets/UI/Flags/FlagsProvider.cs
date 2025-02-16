using UnityEngine;

public class FlagsProvider : MonoBehaviour
{
	private const string FLAGS = "Flags";

	public static Sprite Load(string country)
	{
		var path = System.IO.Path.Combine(FLAGS, country);

		var sprite = Resources.Load<Sprite>(path);

		return sprite;
	}
}
