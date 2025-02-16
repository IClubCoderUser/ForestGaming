using Assets.Scripts.Framework;
using System.Collections.Generic;

using UnityEngine;

public class EconomicRepository : MonoBehaviour, IRepository<long>, IMetadataProvider<EconomicItem>
{
	private Dictionary<long, EconomicItem> _repository = new Dictionary<long, EconomicItem>()
	{
		{ 0, new EconomicItem{ Name="Нефть", Value=10, Description="нефть, нужна для передвижения" } },
		{ 1, new EconomicItem{ Name="Монеты", Value=20, Description="монеты, нужны для покупки юнитов" } },
		{ 2, new EconomicItem{ Name="Валюта", Value=30, Description="валюты, нужны для ..." } }
	};

	/// <summary>Возвращает значение ресурса по id.</summary>
	/// <param name="id">Уникальный id ресурса.</param>
	/// <returns></returns>
	public long GetById(long id)
	{
		return _repository[id].Value;
	}

	/// <summary>Добавляет к текущему значению ресурса передаваемое значение.</summary>
	/// <param name="id">Уникальный id ресурса.</param>
	/// <returns></returns>
	public bool AddById(long id, long el)
	{
		_repository[id].Value += el;

		return true;
	}

	/// <summary>Вычитает у текущего значения ресурса передаваемое значение.</summary>
	/// <param name="id">Уникальный id ресурса.</param>
	/// <returns></returns>
	public bool SubById(long id, long el)
	{ 
		_repository[id].Value -= el;

		return true;
	}

	/// <summary>Возвращает данные об ресурсе.</summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public EconomicItem GetMetaDataById(long id)
	{
		return _repository[id];
	}
}
