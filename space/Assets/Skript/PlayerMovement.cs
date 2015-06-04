/**
 * Bewegung des spielers per Maus und Tastatur
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement: MonoBehaviour
{
	public float speed = 1;
	public float maxspeed = 5;
	public Vector3 target;
	public Vector3 start;
	private Vector3 pos;
	public int turn = 10;
	public bool status = false;

	
	void Start(){
		start = transform.position;
		pos = transform.position;
	}
	
	void FixedUpdate()
	{
		//Status - false, wenn rennen (noch) nicht läuft
		if (status){

			if(Input.GetKey(KeyCode.W) && speed <= maxspeed )
			{
				speed = speed +0.1f;
			}
			if(Input.GetKey(KeyCode.S) && speed > 0)
			{
				speed = speed -.05f;
			}

				pos = Input.mousePosition;
				pos.z = 45;
				pos = Camera.main.ScreenToWorldPoint(pos);
			
			transform.position = Vector3.Lerp(transform.position, pos, speed*Time.deltaTime);
			transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
			transform.Rotate(Vector3.up * turn * Input.GetAxis("Horizontal") * Time.deltaTime);
		}
	}
	

	
}

