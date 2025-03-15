using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DictionaryUI : MonoBehaviour
{

    public PlayerDictionary playerDictionary;
    public GameObject buttonPrefab;
    public GameObject buttonParent;
    //[SerializeField] int wordsOnPage;

 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    
   
    }

    private void OnEnable()
    {
        //MakeButton();
    }

    public void MakeButton(string chineseChar, string englishTrans)
    {

        GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
        newButton.GetComponent<WordDisplay>().chineseCharacter.text = chineseChar;
        newButton.GetComponent<WordDisplay>().englishTranslation.text = englishTrans;
    
    }
}
