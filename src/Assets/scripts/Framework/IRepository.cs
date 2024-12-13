namespace Assets.Scripts.Framework
{
	/// <summary>Контракт репозитория.</summary>
	/// <typeparam name="T"></typeparam>
	internal interface IRepository<T>
	{
		T GetById(long id);

		bool AddById(long id, T value);

		bool SubById(long id, T value);
	}

	/// <summary>Контракт репозитория.</summary>
	/// <typeparam name="T"></typeparam>
	internal interface IMetadataProvider<T>
	{
		T GetMetaDataById(long id);
	}
}
