using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerExit (Collider other)
	{
		Destroy (other.gameObject);
	}
}

// Boundary game object's behavior driven by the box collider, which is trigger

// OnTriggerExit is called when the other collider has stopped touching trigger