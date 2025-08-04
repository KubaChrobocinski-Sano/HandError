using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMatching : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject realController;
    public GameObject keyboardController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyboardController.transform.position = realController.transform.position;
        keyboardController.transform.rotation = realController.transform.rotation;
    }
}
