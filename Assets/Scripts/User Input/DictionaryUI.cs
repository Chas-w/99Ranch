using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DictionaryUI : MonoBehaviour
{
    [Header("Button Data")]
    public GameObject buttonPrefab;
    public GameObject leftButtonParent;
    public GameObject rightButtonParent;

    [Header("Page Data")]
    [SerializeField] int maxWordsOnPage;
    [SerializeField] GameObject leftPagePrefab;
    [SerializeField] GameObject rightPagePrefab;
    public GameObject leftPageParent; 
    public GameObject rightPageParent;
    [SerializeField] List<GameObject> leftPage;
    [SerializeField] List<GameObject> rightPage;

    int currentPage = 0; 
    int currentWordsOnPage;
    bool addingWords;
    GameObject currentPageDisplay; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        addingWords = false; 
        NavigatePages();
    }

    private void OnEnable()
    {

        //sfx probably
    }

    public void MakeButton(string chineseChar, string englishTrans, bool madeButton)
    {

        if (!madeButton && currentWordsOnPage < maxWordsOnPage) 
        {
            addingWords = true;
            if (currentWordsOnPage % 2 == 0)
            {
                GameObject newButton = Instantiate(buttonPrefab, leftPage[leftPage.Count - 1].transform);
                newButton.GetComponent<WordDisplay>().chineseCharacter.text = chineseChar;
                newButton.GetComponent<WordDisplay>().englishTranslation.text = englishTrans;
            } 
            else
            {
                GameObject newButton = Instantiate(buttonPrefab, rightPage[rightPage.Count - 1].transform);
                newButton.GetComponent<WordDisplay>().chineseCharacter.text = chineseChar;
                newButton.GetComponent<WordDisplay>().englishTranslation.text = englishTrans;
            }
            


            currentWordsOnPage++; 
            madeButton = true; 
        }

        MakeNewPage();
    }

    private void MakeNewPage()
    {
        if (currentWordsOnPage >= maxWordsOnPage)
        {
            addingWords = true; 

            leftPage[leftPage.Count - 1].SetActive(false);
            rightPage[rightPage.Count - 1].SetActive(false);

            GameObject newLeftPage = Instantiate(leftPagePrefab, leftPageParent.transform);
            GameObject newRightPage = Instantiate(rightPagePrefab, rightPageParent.transform);

            leftPage.Add(newLeftPage);
            rightPage.Add(newRightPage);

            currentWordsOnPage = 0;
            //currentPage++;

            Debug.Log(currentPage);
        }
    }

    private void NavigatePages()
    {
        if (!addingWords)
        {
            if (Input.GetKeyDown(KeyCode.A) && leftPage[currentPage-1] != null)
            {
                
            }
        }
    }


    private void FirstPage()
    {

    }

    private void LastPage()
    {

    }

}
