using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float smoothTime = 0.1f; //примерно

    private Vector3 vel;

    public void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, character.position - Vector3.one, ref vel, smoothTime); //плавно перемещает камеру в точку координату персонажа
        transform.forward = Vector3.SmoothDamp(transform.forward, character.forward, ref vel, smoothTime); //плавно перемещает forward (поворачивает) cameraRig чтобы смотреть в то же место, куда и персонаж.

        //можно еще иметь ссылку на саму камеру и сделать что-то типа
        transform.LookAt(character.position); // смотрит на персонажа

        // ну также можно сюда засунуть облет препятствий, например, если сзади стена, то подлетаешь камерой (делаешь Z меньше) к персонажу
    }
}
