using Assets.Scripts.Framework;

namespace Assets.scripts.Framework
{
	/// <summary>Описывает проваайдер динамических ресурсов.</summary>
	internal class ResourceProvider<T> : IProvider<T> where T : UnityEngine.Object
	{
		public string Folder { get; }

		public ResourceProvider(string folder) 
		{
			Folder = folder;
		}

		public T LoadByName(string name)
		{ 
			return UnityEngine.Resources.Load<T>($"{Folder}/{name}");
		}
	}
}
