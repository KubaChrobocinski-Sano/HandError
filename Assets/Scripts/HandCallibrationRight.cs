using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCallibrationRight : MonoBehaviour
{
    public GameObject rightHandTip;
    public GameObject rightmarker;
    public GameObject rightHandWrist;
    public GameObject SpaceBar;
    bool hasRightCallibrated;
    // Start is called before the first frame update

    void Start()
    {
        hasRightCallibrated = false;
    }

    // Update is called once per frame
    void Update()
    {
        rightmarker.transform.position = rightHandTip.transform.position;
        string name = rightHandWrist.name;
        

        Vector3 transVector = rightmarker.transform.position - SpaceBar.GetComponent<Renderer>().bounds.center;

        if ((name == "Right Hand Tracking") && (hasRightCallibrated == false) && Input.GetKeyDown(KeyCode.Space))
        {
            rightHandWrist.transform.position -= transVector;
            Debug.Log("Right Callibrated");
            hasRightCallibrated = true;
        }

    }
}
