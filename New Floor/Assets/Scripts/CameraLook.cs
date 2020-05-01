using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
	Vector2 rotation = new Vector2(0, 0);
	public float speed = 3;
	public float minX, minY, maxX, maxY;

	private void Start()
	{
		//Cursor.lockState=CursorLockMode.Locked; 
	}
	//Get mouse position on screen and change camera rotation
	//tbd add slerpt to smooth movement
	void Update()
	{
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x += -Input.GetAxis("Mouse Y");
		//Clamp to limit view
		rotation.x = Mathf.Clamp(rotation.x, minX, maxX);
		rotation.y = Mathf.Clamp(rotation.y, minY, maxY);
		transform.eulerAngles = (Vector2) rotation * speed;
	}
}
