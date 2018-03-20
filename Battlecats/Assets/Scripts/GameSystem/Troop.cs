using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Faction
{
	Left,
	Right //NOSOTROS
}

public class Troop : MonoBehaviour 
{
	public Sprite Card;
	public int price;
	public int health;
	public Faction faction;
	public float coolDown = 5;

	SpriteRenderer sr;

	void Start()
	{
		sr = GetComponent<SpriteRenderer> ();

		sr.sortingOrder = -(int)(transform.position.y * 1000);

	}
}
