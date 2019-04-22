using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;



public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Sprite[] categorySprites;
    [SerializeField] private Sprite[] inventoryItemsSprites;
    [SerializeField] private Sprite originalSprite;

    [SerializeField] private Button[] inventoryButtons;
    [SerializeField] private Button[] categoryButtons;

    [SerializeField] private GameObject[] inventoryItems;

    [SerializeField] private Transform[] parentPositions;
    [SerializeField] private Transform[] realPlayerPositions;

    private List<GameObject> tempInstantiates;

    // Use this for initialization
    /* private void Start()
     {
         for (int i = 0; i < categorySprites.Length; i++)
         {
             categoryButtons[i].GetComponent<Image>().sprite = categorySprites[i];

             categoryButtons[i].gameObject.name = categorySprites[i].name.Split('_')[1];

             string tmpName = categoryButtons[i].gameObject.name;
             Button tempBtn = categoryButtons[i].GetComponent<Button>();
             tempBtn.onClick.AddListener(delegate { OnCategoryButtonClick(tmpName); });


             if (i == 0)
             {
                 Vector2 pos = Camera.main.WorldToScreenPoint(tempBtn.transform.position);
                 CursorControl.SetLocalCursorPos(pos);
                 CursorControl.SimulateLeftClick();
             }


         }

     }
     */

    void OnDisable()
    {
        for (int i = 0; i < tempInstantiates.Count; i++)
        {
            Time.timeScale = 0;
            tempInstantiates[i].transform.parent = realPlayerPositions[i];
            tempInstantiates[i].transform.localPosition = Vector3.zero;
            tempInstantiates[i].transform.localScale = new Vector3(1f, 1f, 1f);
            tempInstantiates[i].transform.localRotation = Quaternion.identity;
            Time.timeScale = 1;
            GameManager.chosedInventory = tempInstantiates;
            //GameManager.updatePlayer();
            

        }
        foreach (Button b in inventoryButtons)
        {
            //b.GetComponent<Animator>().enabled = false;
            b.GetComponent<Image>().sprite = originalSprite;
            b.GetComponent<Button>().transform.localScale = Vector3.one;
            b.GetComponent<Button>().onClick.RemoveAllListeners();
            b.GetComponent<Animator>().ResetTrigger("Highlighted");

        }
    }

    void OnEnable()
    {

       

        Debug.Log("onEnabled");
        if (GameManager.chosedInventory != null)
        {
            tempInstantiates = new List<GameObject>();
            tempInstantiates = GameManager.chosedInventory;
            
        }
        else
        {
            tempInstantiates = new List<GameObject>();
        }

        for (int i = 0; i < tempInstantiates.Count; i++)
        {

            foreach (Transform t in parentPositions)
            {
                if (tempInstantiates[i].name.Contains(t.name))
                {
                    //GameManager.chosedInventory.Remove(tempInstantiates[i]);
                    GameObject tempInventory = Instantiate(tempInstantiates[i], t);
                    tempInstantiates.Add(tempInventory);
                    tempInstantiates.RemoveAt(i);
                    
                }
            }
        }

        foreach (Transform t in realPlayerPositions)
        {
            for (int i = 0; i < t.childCount; i++)
            {
                Destroy(t.GetChild(i).gameObject);
            }
        }



        for (int i = 0; i < categorySprites.Length; i++)
        {
            categoryButtons[i].GetComponent<Image>().sprite = categorySprites[i];

            categoryButtons[i].gameObject.name = categorySprites[i].name.Split('_')[1];

            string tmpName = categoryButtons[i].gameObject.name;
            Button tempBtn = categoryButtons[i].GetComponent<Button>();
            tempBtn.onClick.AddListener(delegate { OnCategoryButtonClick(tmpName); });


            if (i == 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Vector2 pos = Camera.main.WorldToScreenPoint(tempBtn.transform.position);
                CursorControl.SetLocalCursorPos(pos);
                Invoke("ClickTime", 0.05f);
                
            }


        }
    }

    void ClickTime()
    {
        CursorControl.SimulateLeftClick();

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnCategoryButtonClick(string categoryName)
    {
        foreach (Button b in inventoryButtons)
        {
            b.GetComponent<Image>().sprite = originalSprite;
            b.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        for (int i = 0, j=0; i < inventoryItemsSprites.Length; i++)
        {
            if (categoryName == "Gear")
            {

            }
            else if (inventoryItemsSprites[i].name.Contains(categoryName))
            {
                string tmpName = inventoryItemsSprites[i].name.Split('_')[0];

                //Debug.Log(i);
                inventoryButtons[j].gameObject.name = tmpName;
                inventoryButtons[j].GetComponent<Image>().sprite = inventoryItemsSprites[i];
                inventoryButtons[j].GetComponent<Button>().onClick.AddListener(delegate { OnInventoryButtonClick(tmpName); });
                j++;
            }
        }
    }

    private void OnInventoryButtonClick(string inventoryItemName)
    {
        Debug.Log(inventoryItemName + " clicked");

        foreach (Transform t in parentPositions)
        {
            if (inventoryItemName.Contains(t.name))
            {
                foreach (GameObject g in inventoryItems)
                {

                    for(int i = 0; i < tempInstantiates.Count; i++)
                    {

                         if (tempInstantiates[i].name.Contains(g.name))
                         {
                            Destroy(tempInstantiates[i]);
                            tempInstantiates.Remove(tempInstantiates[i]);

    
                            return;
                                
                         }
                        else
                        {

                        }
                        //tempInstantiates.Remove(temp);
                    }
                    
                    if (g.name == inventoryItemName)
                    {
                        tempInstantiates = new List<GameObject>();
                        GameObject tempInventory = Instantiate(g, t);
                        tempInstantiates.Add(tempInventory);
                        tempInventory.layer = 9;
                        foreach (Transform child in tempInventory.transform)
                        {
                            if (null == child)
                            {
                                continue;
                            }
                            child.gameObject.layer = 9;
                        }
                        tempInventory = null;
                    }
                }
            }
        }
    }
}
