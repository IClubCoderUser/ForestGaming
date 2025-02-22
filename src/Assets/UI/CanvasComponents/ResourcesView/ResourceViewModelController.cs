using Assets.Economic;

using UnityEngine;
using UnityEngine.UI;


public class ResourceViewModelController : IController
{
	public EconomicRepository EconomicRepository;

	public Text Money;
	public Text Oil;
	public Text Valuet;

	public long MoneyProperty
	{
		get => Money?.text.ToInt32() ?? int.MinValue;
		set
		{
			if(Money != null)
			{
				Money.text = value.ToString();
			}
		}
	}

	public long OilProperty
	{
		get => Oil?.text.ToInt32() ?? int.MinValue;
		set
		{
			if(Oil != null)
			{
				Oil.text = value.ToString();
			}
		}
	}

	public long ValuetProperty
	{
		get => Valuet?.text.ToInt32() ?? int.MinValue;
		set
		{
			if(Valuet != null)
			{
				Valuet.text = value.ToString();
			}
		}
	}

	public override int Order => OrderUpdateController.PostUpdate;

	public override void Init()
	{
		EconomicRepository = GameObject.FindObjectOfType<EconomicRepository>();

		if(EconomicRepository == null)
		{
			Debug.LogError($"{nameof(ResourceViewModelController)}.{nameof(Init)}()");
			return;
		}

		if(Money == null)
		{
			Money = GameObject.Find("MoneyUI").GetComponentInChildren<Text>();
		}
		if(Oil == null)
		{
			Oil = GameObject.Find("OilUI").GetComponentInChildren<Text>();
		}
		if(Valuet == null)
		{
			Valuet = GameObject.Find("ValuetUI").GetComponentInChildren<Text>();
		}

		MoneyProperty  = 0;
		OilProperty    = 0;
		ValuetProperty = 0;
	}


	public override void StateUpdate()
	{
		MoneyProperty  = EconomicRepository.GetById(0);
		OilProperty    = EconomicRepository.GetById(1);
		ValuetProperty = EconomicRepository.GetById(2);
	}
}

public static class StrToInt32
{
	public static int ToInt32(this string str)
	{
		if(int.TryParse(str, out int result))
		{
			return result;
		}

		return int.MinValue;
	}
}

public static class OrderUpdateController
{
	/// <summary>Приоритет: обновляет после.</summary>
	public static int PostUpdate = 100;
}
