using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour {
	public Button button;
	public Image image;


	public void SetCard(Sprite sprite, System.Action action)
	{
		image.sprite = sprite;

		button.onClick.RemoveAllListeners ();
		button.onClick.AddListener (action.Invoke);

	}

}
