using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour 
{
	public Base baseToControll;
	public Transform layout;
	public CardButton cardButtonPrefab;


	public void OnStart () 
	{
		for (int i = 0; i < baseToControll.troops.Length; i++) 
		{
			int u = i;
			var go = Instantiate (cardButtonPrefab, layout);
			go.SetCard (baseToControll.troops [i].Card, () => {
				baseToControll.Instantiate(u);		
			},
				baseToControll.troops [i].price.ToString()
			);
			go.transform.position = Vector3.zero;
		}	
	}

}
