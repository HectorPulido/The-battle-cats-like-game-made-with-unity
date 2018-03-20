using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TroopMovement : MonoBehaviour 
{
	public float velocity = 10;
	public int damage;
	public float candency = 1;
	public LayerMask layer;
	public GameObject prefabMario;

	Troop tr;
	void Start () 
	{
		tr = GetComponent<Troop> ();
		fwd = tr.faction == Faction.Right ? Vector2.left : Vector2.right;
		InvokeRepeating ("Fight", candency, candency);

	}

	Vector2 fwd;
	RaycastHit2D rh;
	bool fighting = false;
	void Update ()
	{
		rh = Physics2D.Raycast (transform.position, fwd, 0.4f, layer);
		fighting = rh.collider != null;

		if (!fighting) {
			transform.position += Vector3.right * velocity * Time.deltaTime;		
		}
	
	}
	void Fight()
	{
		if (!fighting)
			return;
		if (rh.collider == null)
			return;
		
		var b = rh.collider.GetComponent<Base> ();
		var t = rh.collider.GetComponent<Troop> ();

		if (b != null) { // DESTRUIMOS LA BASE
			b.health -= damage;
			if (b.health <= 0) {
				//WINSTAT
				GlobalGameManager.singleton.score += 1000;
				GlobalGameManager.singleton.GoToScene ("Menu");
			}


		} else if(t != null) {
			t.health -= damage;
			if (t.health <= 0) {
				Instantiate (prefabMario, t.transform.position, Quaternion.identity);
				Destroy (t.gameObject, 0.1f);
			}
		}
	}
}
