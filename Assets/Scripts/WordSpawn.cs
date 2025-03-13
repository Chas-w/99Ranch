using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WordSpawn : MonoBehaviour
{
    [Header("Word Data")]
    [SerializeField] TextMeshProUGUI textMeshObject;
    [SerializeField] float spawnSpeedMax;
    public int currentMessage;
    public bool nextMessage;
    public bool triggerText = false; 


    [Header("Message Contents")]
    public string[] message;
    [SerializeField] string[] messageDeconstructed;

    string displayMessage = "";
    float spawnSpeed;
    int i = 0;

    // Start is called before the first frame update
    private void Start()
    {
        //spawnSpeed = spawnSpeedMax;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //cycle through dialogue
        {
            currentMessage++; 
            nextMessage = false;
            ResetMessage();
        }

        ShowMessage(); 

        textMeshObject.text = displayMessage;


    }

    public void ResetMessage()
    {
        spawnSpeed = spawnSpeedMax;
        i = 0;
        displayMessage = "";
        return; 
    }

    private void ShowMessage()
    {
        messageDeconstructed = message[currentMessage].Split(' ');

        /*
        for (;  i < messageDeconstructed.Length; i++)
        {


            if (spawnSpeed < 0) 
            {
                displayMessage += messageDeconstructed[i] + " ";
            }

        }
        */
        
        if (spawnSpeed >= 0)
        {
            spawnSpeed -= Time.deltaTime;
            if (spawnSpeed < 0 && i < messageDeconstructed.Length)
            {
                spawnSpeed = spawnSpeedMax;
                displayMessage += messageDeconstructed[i] + " ";
                i++;

            }
            Debug.Log(i);
        }



    }

}
