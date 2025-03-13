using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Highlighting : MonoBehaviour
{
    [SerializeField] Transform[] highlightPosition;

    int positionCycle = 0; 
    Vector3 highlightTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highlightTransform = transform.position;
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (positionCycle < highlightPosition.Length - 1)
            {
                positionCycle++;
            }
            else 
            {
                positionCycle = 0;
            }
        }

        transform.position = new Vector3(transform.position.x, highlightPosition[positionCycle].position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Word")
        {
           // Debug.Log(other.gameObject.name);
        }
    }
}
