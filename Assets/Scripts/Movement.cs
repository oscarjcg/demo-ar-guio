using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private float rotationVelocity = 500f;
    private float distance = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    // TODO: Corutina para el suavizar el movimiento
    public void RotationLeft()
    {
        GetComponent<Transform>().Rotate(new Vector3(0f, rotationVelocity, 0f) * Time.deltaTime);
    }

    public void RotationRight()
    {
        GetComponent<Transform>().Rotate(new Vector3(0f, -rotationVelocity, 0f) * Time.deltaTime);
    }

    public void RotationUp()
    {
        GetComponent<Transform>().Rotate(new Vector3(rotationVelocity, 0f, 0f) * Time.deltaTime);
    }

    public void RotationDown()
    {
        GetComponent<Transform>().Rotate(new Vector3(-rotationVelocity, 0f, 0f) * Time.deltaTime);
    }

    public void Left()
    {
        GetComponent<Transform>().Translate(new Vector3(-distance, 0f, 0f));
    }

    public void Right()
    {
        GetComponent<Transform>().Translate(new Vector3(distance, 0f, 0f));
    }

    public void Up()
    {
        GetComponent<Transform>().Translate(new Vector3(0f, distance, 0f));
    }

    public void Down()
    {
        GetComponent<Transform>().Translate(new Vector3(0f, -distance, 0f));
    }
}
