using UnityEngine;

public class CameraRig : MonoBehaviour
{



    // Second version
    [SerializeField] private Transform _character;
    [SerializeField] private float smoothTime = 0.05f; 

    private Vector3 vel;
    
    //private Vector3 _offset;

    //private void Start()
    //{
    //    _offset = _character.position - transform.position;
    //}

    //public void Update()
    //{
    //   transform.position = _character.position - _offset;
    //}

    public void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _character.position, ref vel, smoothTime); //плавно перемещает камеру в точку координату персонажа
        transform.forward = Vector3.SmoothDamp(transform.forward, _character.forward, ref vel, smoothTime); //плавно перемещает forward (поворачивает) cameraRig чтобы смотреть в то же место, куда и персонаж.
        
    }
}
