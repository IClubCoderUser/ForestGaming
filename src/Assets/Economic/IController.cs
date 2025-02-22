using UnityEngine;

namespace Assets.Economic
{
	public abstract class IController : MonoBehaviour
	{
		public abstract int Order { get; }

		public abstract bool Init();

		public abstract void StateUpdate();
	}
}
