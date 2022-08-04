using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
//[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
	public Transform cameraT;

	public float moveSpeed = 5f;
	public float rotationSpeed = 5f;

	PlayerController controller;
	//GunController gunController;
	//Camera viewCamera;

	void Start()
	{
		controller = GetComponent<PlayerController>();
		//gunController = GetComponent<GunController>();
		
		if (cameraT == null)
			cameraT = Camera.main.transform;
		//viewCamera = Camera.main;
	}

	void Update()
	{
		// Movement input
		Vector3 cameraForward = cameraT.forward;
		Vector3 cameraRight = cameraT.right;

		cameraForward.y = 0;
		cameraRight.y = 0;

		cameraForward.Normalize();
		cameraRight.Normalize();

		Vector3 moveInput = cameraRight * Input.GetAxisRaw("Horizontal") + cameraForward * Input.GetAxisRaw("Vertical");
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move(moveVelocity);

		//Rotate object to move direction
		moveInput.Normalize();

		if (moveInput != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(moveInput, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
		}

		// Look input
		//Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
		//Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		//float rayDistance;

		//if (groundPlane.Raycast(ray, out rayDistance))
		//{
		//	Vector3 point = ray.GetPoint(rayDistance);
		//	//Debug.DrawLine(ray.origin,point,Color.red);
		//	controller.LookAt(point);
		//}

		//// Weapon input
		//if (Input.GetMouseButton(0))
		//{
		//	gunController.Shoot();
		//}
	}
}