using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloobSound : MonoBehaviour
{
    public AudioSource bloobSound;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision){
        bloobSound.Play();
    }
}
