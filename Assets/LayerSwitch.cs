using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LayerSwitch : MonoBehaviour
{
    private List<GameObject> _layer1;
    private List<GameObject> _layer2;

    private int _currentLayer = 1;

    void Start()
    {
        // можно еще с помощью spherecast

        var gameobjects = FindObjectsOfType<GameObject>();

        _layer1 = gameobjects
            .Where(g => g.layer.Equals(LayerMask.NameToLayer("layer1")))
            .ToList();

        _layer2 = gameobjects
            .Where(g => g.layer.Equals(LayerMask.NameToLayer("layer2")))
            .ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(_currentLayer == 1)
                _currentLayer = 2;
            else
                _currentLayer = 1;

            bool isCurrentLayer1 = _currentLayer == 1;
            
            _layer1.ForEach(g => g.SetActive(isCurrentLayer1));
            _layer2.ForEach(g => g.SetActive(!isCurrentLayer1));
        }
    }
}
