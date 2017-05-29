using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private Rigidbody rb;
	private float nextFire;
	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource = GetComponent<AudioSource> ();
			audioSource.Play ();
		}
	}
	
	// FixedUpdate is called once per frame before physics step
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}

// If we want to affect physics velocity, we address rigidbody component

// Input.GetAxis returns value between 0 and 1

// Constrain ship by setting value of rigidbody's position
// If we move outside of the game area, set player's position to edge of game area

// Mathf.Clamp clamps a value between a min and max float value (inclusive)

// The number of units from the top of the screen to the bottom is always
// twice the value of our camera's orthographic size