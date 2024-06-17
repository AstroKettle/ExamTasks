using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float shrinkSpeed = 5f;
    private void Update()
    {
         transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;

        // Проверяем, если размер объекта стал меньше или равен 0
        if (transform.localScale.x <= 0)
        {
            // Уничтожаем объект
            Destroy(gameObject);
        }
    }
}
