using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public GameObject inventoryGroup;
    public GameObject inventory1;
    public GameObject inventory2;
    public Toggle player1Toggle;
    public Toggle player2Toggle;
    public Button closeInventoryButton;
    public Toggle openInventoryToggle;
    public Animator slideAnim;


    // Start is called before the first frame update
    void Start()
    {
        //slideAnim.SetBool("shouldSlide", false);
        inventoryGroup.SetActive(false);
        openInventoryToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //openInventory();
    }

    public void openInventory()
    {

        if (openInventoryToggle.isOn == false)
        {
            inventoryGroup.SetActive(true);
            if (player1Toggle.isOn)
            {
                player2Toggle.isOn = false;
                inventory2.SetActive(false);
                inventory1.SetActive(true);
            }
            if (player2Toggle.isOn)
            {
                player1Toggle.isOn = false;
                inventory2.SetActive(true);
            }
        }else{
            inventoryGroup.SetActive(false);
        }
    }
    
    public void closeInventory()
    {
        inventory2.SetActive(false);
        inventory1.SetActive(false);
    }
    

    
    
}
