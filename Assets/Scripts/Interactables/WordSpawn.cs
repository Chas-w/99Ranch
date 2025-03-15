using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class WordSpawn : MonoBehaviour
{
    [Header("Word Data")]
    [SerializeField] TextMeshProUGUI textMeshObject;
    [SerializeField] float spawnSpeedMax;
    public int currentMessage;
    public bool nextMessage;
    public bool triggerText = false;

    [Header("Message Contents")]
    public List<string> message;

    public string[] messageDeconstructed;


    [Header("Translation Data")]
    [Header("Word Data")]
    public string[] translatableWords;
    public string[] translatedSentenceDeconstructed;
    public PlayerDictionary playerDictionary;
    [SerializeField] string newMessage;

    [Header("Audio Data")]
    [SerializeField] AudioSource vocalChords;
    [SerializeField] AudioClip[] voiceSounds;

    [Header("Input Data")]
    [SerializeField] KeyCode nextKey;
    [SerializeField] KeyCode translate;
    [SerializeField] string[] waitingForResponse; 
    //[SerializeField] Button nextButton; 

    public string displayMessage = "";
    float spawnSpeed;
    int i = 0;
    int messageLength; 
    bool playedAudio; 

    // Start is called before the first frame update
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        messageLength = message.Count;

        if (Input.GetKeyDown(nextKey)) //cycle through dialogue
        {
            if (currentMessage < messageLength - 1) //if there is a next dialogue option
            {
                currentMessage++;
            } else { currentMessage = 0; } //otherwise return to the beginning

            ResetMessage(spawnSpeedMax,0,"");
        }

        ShowMessage(); 
        ShowTranslation();

        textMeshObject.text = displayMessage; //display message is the actual text that shows in the game


    }

    public void ResetMessage(float spawnSpeedReset, int wordIterateReset, string displayMessageText)
    {
        spawnSpeed = spawnSpeedReset;
        i = wordIterateReset;
        displayMessage = displayMessageText;
        playedAudio = false;
        return; 
    }

    private void ShowMessage()
    {
        if (!playedAudio) //play the audio ONCE
        {
            vocalChords.PlayOneShot(voiceSounds[Random.Range(0, voiceSounds.Length)]);
            playedAudio = true; 
        }

        messageDeconstructed = message[currentMessage].Split(' '); //puts each word in sentence into an array

        if (spawnSpeed >= 0) //when the timer reaches zero add the words one by one to a display message
        {
            spawnSpeed -= Time.deltaTime;
            if (spawnSpeed < 0 && i < messageDeconstructed.Length) //if the timer is up and i is viable 
            {
                spawnSpeed = spawnSpeedMax; //reset the timer

                for (int j = 0; j < playerDictionary.parsedDictionaryLength; j+=2) //cycle through each TRANSLATABLE word 
                {
                    if (messageDeconstructed[i].Contains(playerDictionary.parsedDictionary[j])) //if the word in the deconstructed sentence has a translatable word
                    {
                        messageDeconstructed[i] = "<gradient=\"Translatable\">" + playerDictionary.parsedDictionary[j] + "</gradient>"; //change the color of the translatable word
                    }
                }

                displayMessage += messageDeconstructed[i] + " "; //add to the sentence
                i++; //cycle i

            }
        }
    }


    private void TranslateSentence() //will probably have to deal with this later to make it work with the translated words inventory; 
    {
        translatedSentenceDeconstructed = messageDeconstructed; //store each word in the sentence in an array *this needs to happen ONCE per updated sentence
        newMessage = "";

        for (int i = 0; i < translatedSentenceDeconstructed.Length; i++) //cycle through each word in the array
        {
            for (int j = 1; j < playerDictionary.parsedDictionaryLength; j+=2) //cycle through each TRANSLATABLE word 
            {
                if (translatedSentenceDeconstructed[i].Contains(playerDictionary.parsedDictionary[j - 1])) //if the word in the deconstructed sentence has a translatable word
                {                    
                    translatedSentenceDeconstructed[i] = "<gradient=\"Translatable\">" + playerDictionary.parsedDictionary[j] + "</gradient>"; //assign the TRANSLATED WORD and replace the TRANSLATABLE word in the deconstructed sentence
                }
            }
            newMessage += translatedSentenceDeconstructed[i] + " "; //construct the sentence
        }

       // return;
    }

    private void ShowTranslation()
    {
        if (Input.GetKeyDown(translate))
        {
            TranslateSentence();
            ResetMessage(0, messageDeconstructed.Length, newMessage);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //TranslateSentence();
            ResetMessage(0, 0, " ");
        }
    }

}
