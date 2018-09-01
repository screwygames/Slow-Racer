using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public int speed;
    public float acceleration;
    public float turnSpeed;
    public Text speedText;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        UpdateSpeedText();
    }
	
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 rotation = new Vector3(0.0f, moveHorizontal, 0.0f);
        Vector3 movement = rb.transform.forward * acceleration * moveVertical;

        //rb.transform.rotation = Quaternion.Euler(rb.transform.rotation.x, moveHorizontal * turnSpeed, rb.transform.rotation.z);
        rb.transform.Rotate(new Vector3(0.0f, moveHorizontal * Time.deltaTime * turnSpeed, 0.0f));
        rb.AddForce(movement * acceleration, ForceMode.Acceleration);
        UpdateSpeedText();
    }

    void UpdateSpeedText()
    {
        speedText.text = rb.velocity.ToString();
    }
}
