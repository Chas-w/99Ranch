using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerDialogue : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] Image[] textOptions;
    [SerializeField] Highlighting highlight; 
    [SerializeField] TextMeshProUGUI playerTextInput;

    Vector3 highlightTransform;

    private void Update()
    {

    }
}
