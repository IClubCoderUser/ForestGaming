using Assets.Scripts.Framework;
using System.Collections.Generic;

using UnityEngine;

public class EconomicRepository : MonoBehaviour, IRepository<long>, IMetadataProvider<EconomicItem>
{
	private Dictionary<long, EconomicItem> _repository = new Dictionary<long, EconomicItem>()
	{
		{ 0, new EconomicItem{ Name="Нефть", Value=0, Description="нефть, нужна для передвижения" } },
		{ 1, new EconomicItem{ Name="Монеты", Value=0, Description="монеты, нужны для покупки юнитов" } },
		{ 2, new EconomicItem{ Name="Валюта", Value=0, Description="валюты, нужны для ..." } },

        //{ 3, new EconomicItem{ Name="Здоровье", Value=0, Description="здоровье юнита" } },
        //{ 4, new EconomicItem{ Name="Защита", Value=0, Description="защита юнита" } },
        //{ 5, new EconomicItem{ Name="Урон", Value=0, Description="урон юнита" } }

    };

	/// <summary>Возвращает значение ресурса по id.</summary>
	/// <param name="id">Уникальный id ресурса.</param>
	/// <returns></returns>
	public long GetById(long id)
	{
		return _repository[id].Value;
	}

	public bool SetById(long id, long el)
	{
		_repository[id].Value = el;

		return true;
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
