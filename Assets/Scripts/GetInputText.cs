using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetInputText : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TMP_InputField inputField;
    void Start()
    {   
        inputField.onDeselect.AddListener(OnInputFieldValueChanged);
    }

    void OnInputFieldValueChanged(string inputText)
    {
        Debug.Log("Input text changed: " + inputText);
        string path = Application.dataPath + "/Log.txt";
        //Create File if it doesn't exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }
        string content = inputText;
        //Add some to text to it
        File.AppendAllText(path, content);
    }
}
