using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour {
	public Button button;
	public Image image;
	public Text text;


	public void SetCard(Sprite sprite, System.Action action, string _text)
	{
		image.sprite = sprite;
		text.text = _text;

		button.onClick.RemoveAllListeners ();
		button.onClick.AddListener (action.Invoke);

	}

}
