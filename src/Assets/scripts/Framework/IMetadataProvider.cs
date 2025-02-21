namespace Assets.Scripts.Framework
{
	/// <summary>Контракт репозитория.</summary>
	/// <typeparam name="T"></typeparam>
	internal interface IMetadataProvider<T>
	{
		T GetMetaDataById(long id);
	}
}
