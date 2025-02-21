using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Helpers
{
	/// <summary>Вспомогательны класс инициализации.</summary>
	public static class Initializer
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Initialize<T>(ref List<T> list)
#if CSHARP_10_0_OR_NEWER
			=> list = new();
#else
			=> list = new List<T>();
#endif

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Initialize<T, D>(ref Dictionary<T, D> list)
#if CSHARP_10_0_OR_NEWER
			=> list = new();
#else
			=> list = new Dictionary<T, D>();
#endif

	}
}
