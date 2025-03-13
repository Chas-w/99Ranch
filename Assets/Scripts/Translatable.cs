using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translatable : MonoBehaviour
{
    public WordSpawn wordSpawn; 
    [SerializeField] bool[] messageTranslatable; 
    public string[] translatableWordsInSentence; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && messageTranslatable[wordSpawn.currentMessage])
        {
            wordSpawn.message[wordSpawn.currentMessage] = translatableWordsInSentence[wordSpawn.currentMessage];
            wordSpawn.ResetMessage();
        }
    }
}
