using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour {

	public Text scoreText;
	public GameObject shop;
	public Transform shopLayout;
	public CardButton cardButtonPrefab;

	void Start(){
		UpdateShop ();
	}

	void UpdateShop()
	{

		scoreText.text = GlobalGameManager.singleton.score.ToString();

		foreach (Transform item in shopLayout) {
			Destroy (item.gameObject);
		}

		for (int i = 0; i < GlobalGameManager.singleton.sellingCats.Count; i++) {
			var go = Instantiate (cardButtonPrefab, shopLayout);
			int u = i;

			go.SetCard (GlobalGameManager.singleton.sellingCats [u].Card, () => {
				if(GlobalGameManager.singleton.score >= 
					GlobalGameManager.singleton.sellingCats [u].price)
				{
					GlobalGameManager.singleton.score -= 
						GlobalGameManager.singleton.sellingCats [u].price;

					GlobalGameManager.singleton.allyTroops.Add(GlobalGameManager.singleton.sellingCats[u]);

					GlobalGameManager.singleton.sellingCats.RemoveAt(u);
					UpdateShop();
				}

			},
				GlobalGameManager.singleton.sellingCats [u].price.ToString()); 
		}
	}

	public void GoToShop()
	{
		shop.SetActive (!shop.activeInHierarchy);
	}
	public void GoToBattle()
	{
		GlobalGameManager.singleton.GoToScene ("Battle");
	}
}
