using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ClickScript : MonoBehaviour
{
    [SerializeField] Camera cam; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo) && Input.GetMouseButtonDown(0))
        {
            Debug.Log(hitInfo.transform.name);
        }
        
    }
}
