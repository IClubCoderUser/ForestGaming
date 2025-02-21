using Assets.Scripts.Framework;
using System.Collections.Generic;

using UnityEngine;

public class EconomicRepository : MonoBehaviour, IRepository<long>, IMetadataProvider<EconomicItem>
{
	private Dictionary<long, EconomicItem> _repository = new Dictionary<long, EconomicItem>()
	{
		{ 0, new EconomicItem{ Name="�����", Value=0, Description="�����, ����� ��� ������������" } },
		{ 1, new EconomicItem{ Name="������", Value=0, Description="������, ����� ��� ������� ������" } },
		{ 2, new EconomicItem{ Name="������", Value=0, Description="������, ����� ��� ..." } }
	};

	/// <summary>���������� �������� ������� �� id.</summary>
	/// <param name="id">���������� id �������.</param>
	/// <returns></returns>
	public long GetById(long id)
	{
		return _repository[id].Value;
	}

	/// <summary>��������� � �������� �������� ������� ������������ ��������.</summary>
	/// <param name="id">���������� id �������.</param>
	/// <returns></returns>
	public bool AddById(long id, long el)
	{
		_repository[id].Value += el;

		return true;
	}

	/// <summary>�������� � �������� �������� ������� ������������ ��������.</summary>
	/// <param name="id">���������� id �������.</param>
	/// <returns></returns>
	public bool SubById(long id, long el)
	{ 
		_repository[id].Value -= el;

		return true;
	}

	/// <summary>���������� ������ �� �������.</summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public EconomicItem GetMetaDataById(long id)
	{
		return _repository[id];
	}
}
