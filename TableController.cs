using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableController : MonoBehaviour
{
    public Animator slideAnim;
    public Toggle player1Tog;
    public Toggle player2Tog;
    public GameObject player1Panel;
    public GameObject player2Panel;

    // Start is called before the first frame update
    void Start()
    {
        player1Panel.SetActive(true);
        player2Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
    }

    public void SlideInTable()
    {
        slideAnim.SetBool("open", true);
    }
    public void SlideOutTable()
    {
        slideAnim.SetBool("open", false);
    }

    public void ToggleInventory()
    {
        if (player1Tog.isOn)
        {
            player1Panel.SetActive(true);
            player2Panel.SetActive(false);
        }
        else if (player2Tog.isOn)
        {
            player1Panel.SetActive(false);
            player2Panel.SetActive(true);
        }
    }

    public void closeInventory()
    {
        player1Panel.SetActive(false);
        player2Panel.SetActive(true);
    }

}
