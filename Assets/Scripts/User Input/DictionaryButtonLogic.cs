using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DictionaryButtonLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wordToDisplay;
    public TextMeshProUGUI textBox;
    public GameObject textBoxObject; 
    // Start is called before the first frame update
    void Start()
    {
        textBoxObject = GameObject.FindWithTag("WordInput");
        textBox = textBoxObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTextBox()
    {
        textBox.text += wordToDisplay.text + " ";
    }
}
