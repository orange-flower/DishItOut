using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchPanel : MonoBehaviour
{
    [Header("Tog and Panel")]
    public Toggle vendorToggle;
    public GameObject recipePanel;
    public GameObject vendorPanel;
    public GameObject recipeBG;
    public GameObject vendorBG;

    // Start is called before the first frame update
    void Start()
    {
        //setup market place
        vendorBG.SetActive(true);
        recipeBG.SetActive(false);

        vendorToggle.isOn = true;
        recipePanel.SetActive(false);
        vendorPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        checkPanel();
    }

    //function to enable one and panel and disable the other depending on the tog state
    public void checkPanel()
    {
        if (vendorToggle.isOn == true)
        {
            vendorBG.SetActive(true);
            recipeBG.SetActive(false);
            recipePanel.SetActive(false);
            vendorPanel.SetActive(true);
        } else
        {
            vendorBG.SetActive(false);
            recipeBG.SetActive(true);
            recipePanel.SetActive(true);
            vendorPanel.SetActive(false);
        }
    }
}
