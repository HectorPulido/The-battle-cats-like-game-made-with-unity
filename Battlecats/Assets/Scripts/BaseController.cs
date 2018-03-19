using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour 
{
	public Base baseToControll;
	public Transform layout;
	public CardButton cardButtonPrefab;


	void Start () 
	{
		for (int i = 0; i < baseToControll.troops.Length; i++) 
		{
			int u = i;
			var go = Instantiate (cardButtonPrefab, layout);
			go.SetCard (baseToControll.troops [i].Card, () => {
				baseToControll.Instantiate(u);		
			});
			go.transform.position = Vector3.zero;
		}	
	}

}
