using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour 
{
	public Faction faction;
	public Troop[] troops;
	float[] coolDowns;
	public Transform pivot;
	public int money;
	public int maxMoney = 200;
	public int health;
	public bool active;

	public Text moneyTxt;

	public Vector2 yRange;

	IEnumerator Start()
	{
		while (!active) {
			yield return null;
		
		}

		coolDowns = new float[troops.Length];
		while (true) {
			for (int i = 0; i < coolDowns.Length; i++) {
				coolDowns [i] -= 0.1f;//t
			}

			if (money < maxMoney) {
				money++;	
				if(moneyTxt != null)
					moneyTxt.text = money + "/" + maxMoney;
			}	
			yield return new WaitForSeconds (0.1f);//t
		}
	}


	public void Instantiate(int id)
	{
		if (!active)
			return;

		if (troops [id].price > money)
			return;
		if (coolDowns [id] >= 0)
			return;
		coolDowns [id] = troops [id].coolDown;
		money -= troops [id].price;
		var pos = new Vector3 (pivot.position.x, Random.Range (yRange.x, yRange.y));
		Instantiate (troops [id], pos, Quaternion.identity);

	}
}
