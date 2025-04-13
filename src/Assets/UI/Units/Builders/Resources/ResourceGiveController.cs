using Assets.Economic;
using UnityEngine;

public class ResourceGiveController : IController
{
	private EconomicRepository EconomicRepository;

	public override int Order => OrderUpdateController.CurrentUpdate;

	public override bool Init()
	{
		if(EconomicRepository == null)
		{
			EconomicRepository = GameObject.FindObjectOfType<EconomicRepository>();
		}
		
		return true;
	}

	public override void StateUpdate()
	{
		var builds = UnityEngine.GameObject.FindObjectsOfType<ItemResources>();

		foreach(var build in builds) 
		{
			EconomicRepository.AddById(build.ResourceId, build.Output);
		}
	}
}
