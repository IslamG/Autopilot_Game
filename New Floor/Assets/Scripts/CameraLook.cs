using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
	Vector2 rotation;
	[SerializeField]
	private float speed = 3, minX, minY, maxX, maxY;
	Camera cam;
	private void Start()
	{
		//Cursor.lockState=CursorLockMode.Locked;
		cam= gameObject.GetComponent<Camera>();
		rotation = new Vector2(cam.transform.rotation.x, cam.transform.rotation.y);
	}
	//Get mouse position on screen and change camera rotation
	//tbd add slerp to smooth movement
	void Update()
	{
		if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
		{
			rotation.y += Input.GetAxis("Mouse X");
			rotation.x += -Input.GetAxis("Mouse Y");
			//Clamp to limit view
			rotation.x = Mathf.Clamp(rotation.x, minX, maxX);
			rotation.y = Mathf.Clamp(rotation.y, minY, maxY);
			cam.transform.localEulerAngles = (Vector2) rotation * speed;
		}
	}
}
