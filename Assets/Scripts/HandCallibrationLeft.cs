using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCallibrationLeft : MonoBehaviour
{
    public GameObject leftHandTip;
    public GameObject leftmarker;
    public GameObject leftHandWrist;
    public GameObject SpaceBar;
    bool hasLeftCallibrated;
    // Start is called before the first frame update

    void Start()
    {
        hasLeftCallibrated = false;
    }

    // Update is called once per frame
    void Update()
    {
        leftmarker.transform.position = leftHandTip.transform.position;
        string name = leftHandWrist.name;
        
        
        Vector3 transVector = leftmarker.transform.position - SpaceBar.GetComponent<Renderer>().bounds.center;

        if ((name == "Left Hand Tracking") && (hasLeftCallibrated == false) && Input.GetKeyDown(KeyCode.Space))
        {
            leftHandWrist.transform.position -= transVector;
            Debug.Log("Left Callibrated");
            hasLeftCallibrated = true;
        }
      
    }
}
