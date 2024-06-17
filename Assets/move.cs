using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0,0,1)*speed);
        } else if(Input.GetKey(KeyCode.S)) {
            transform.Translate(new Vector3(0,0,-1)*speed);
        } else if(Input.GetKey(KeyCode.D)) {
            transform.Translate(new Vector3(1,0,0)*speed);
        } else if(Input.GetKey(KeyCode.A)) {
            transform.Translate(new Vector3(-1,0,0)*speed);
        }
    }
}
