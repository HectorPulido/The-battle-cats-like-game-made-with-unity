using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour 
{

	public Base baseToControll;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnEnemy", 0.5f, 0.5f);	
	}
	
	// Update is called once per frame
	void SpawnEnemy () 
	{
		baseToControll.Instantiate (Random.Range (0, baseToControll.troops.Length));
	}
}
