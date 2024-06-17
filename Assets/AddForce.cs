using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0) {
            if(Input.GetAxis("Horizontal") > 0) {
                RB.AddForce(Vector3.right * speed);
            } else if (Input.GetAxis("Horizontal") < 0) {
                RB.AddForce(Vector3.left * speed);
            }
        } else if(Input.GetAxis("Vertical") != 0) {

            if(Input.GetAxis("Vertical") > 0) {
                RB.AddForce(Vector3.forward * speed);
            } else if (Input.GetAxis("Vertical") < 0) {
                RB.AddForce(Vector3.back * speed);
            }
        }
    }
}
