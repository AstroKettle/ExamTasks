using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyOnClick : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData data){
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
