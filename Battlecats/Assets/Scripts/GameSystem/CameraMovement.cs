using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{

	public float cameraVelocity;
	public Vector2 cameraBounds;

	void Update () 
	{
		var posx = transform.position.x;
		posx += cameraVelocity * Time.deltaTime * Input.GetAxis ("Horizontal");
		posx = Mathf.Clamp (posx, cameraBounds.x, cameraBounds.y);

		transform.position = new Vector3 (posx,
			transform.position.y, 
			transform.position.z);

	}
}
