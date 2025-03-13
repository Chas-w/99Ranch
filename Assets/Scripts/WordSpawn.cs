using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WordSpawn : MonoBehaviour
{
    [Header("Word Data")]
    [SerializeField] TextMeshProUGUI textMeshObject;
    [SerializeField] int spawnSpeedMax;
    [SerializeField] int currentMessage;
    public bool nextMessage;
    public bool triggerText = false; 


    [Header("Message Contents")]
    [SerializeField] string[] message;
    [SerializeField] string[] messageDeconstructed;

    string displayMessage = "";
    float spawnSpeed;
    int i = 0;

    // Start is called before the first frame update
    private void Start()
    {
        spawnSpeed = spawnSpeedMax;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //cycle through dialogue
        {
            currentMessage++;
            i = 0; 
            nextMessage = false;
            displayMessage = ""; 
        }

        ShowMessage(); 

        textMeshObject.text = displayMessage;


    }


    private void ShowMessage()
    {
        messageDeconstructed = message[currentMessage].Split(' ');

        do
        {

            if (messageDeconstructed[i] != null)
            {
                displayMessage += messageDeconstructed[i] + " ";
                i++;
                Debug.Log(i);
            }

        }
        while (i <= messageDeconstructed.Length - 2);

   

    }

}
