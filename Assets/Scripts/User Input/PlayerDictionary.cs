using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class PlayerDictionary : MonoBehaviour
{
    [Header("Word Containers")]
    public List<string> allDictionary;
    public List<string> parsedDictionary;

    [Header("Parsing Data")]
    string mergedDictionary;
    public int parsedDictionaryLength; 
    
    int allDictionaryLength;

    [Header("UI Data")]
    public DictionaryUI dictionaryUI;
    public bool resetParsed;

    bool updatedDictionary;
    bool assignParsedUI;
    int j = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allDictionaryLength = allDictionary.Count;
        parsedDictionaryLength = parsedDictionary.Count;

        parsedDictionary.RemoveAll(s => s == "");

        UpdateDictionary();
        AssignParsedData();

        ResetParsedDictionary();
    }

    private void UpdateDictionary()
    {
        if (!updatedDictionary)
        {

            for (int i = 0; i < allDictionaryLength; i++) //cycle through each  word
            {
                mergedDictionary += allDictionary[i]; //merge into one string
            }
            parsedDictionary = mergedDictionary.Split(':').ToList(); //parse through the merged dictionary and add each word into an array
            updatedDictionary = true;
        }
    }

    private void AssignParsedData()
    {
        if (!assignParsedUI)
        {
      
            do
            {
                dictionaryUI.MakeButton(parsedDictionary[j], parsedDictionary[j + 1], false);
                j += 2;

            }
            while (j < parsedDictionary.Count -2);

            if (j > parsedDictionary.Count - 2) 
            {
                assignParsedUI = true;
            }
           // assignTOUI = true;
        }

        if (j < parsedDictionary.Count - 2)
        {
            assignParsedUI = false; 
        }
 
    }

    private void ResetParsedDictionary()
    {

        if (!resetParsed)
        {
            parsedDictionary.Clear();
            mergedDictionary = "";
            updatedDictionary = false;
            resetParsed = true;
        }
    }



}
