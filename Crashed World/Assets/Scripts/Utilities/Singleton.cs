using UnityEngine;

namespace CrashedWorld.Utilities
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		public static T Instance
		{
			get
			{
				if (instance == null)
					Debug.Log(typeof(T).Name + " was not found and has not been created.");

				return instance;
			}
		}
		private static T instance;

		private void Awake()
		{
			instance = this as T;
			OnAwake();
		}

		protected virtual void OnAwake() { }
	}
}

