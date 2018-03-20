using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour 
{
	public Base leftBase;
	public Base rightBase;
	public BaseController controller;

	public void Init(Troop[] leftTroops, Troop[] rightTroops)
	{
		leftBase.troops = leftTroops; 
		rightBase.troops = rightTroops;

		leftBase.active = true;
		rightBase.active = true;

		controller.OnStart ();
	}

}
