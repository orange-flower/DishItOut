using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController current;

    [Header("Script Refs")]
    public Player player1;
    public Player player2;
    public Text turnIndicator;

    [Header("Toggle Group")]
    public GameObject ingredientGroup;
    public GameObject recipeGroup;
    public Text[] p1IngCount = new Text[10];
    public Text[] p2IngCount = new Text[10];
    public Toggle[] ingredientToggleList = new Toggle[9];

    [Header("Buttons")]
    public Button buybutton;
    public Button selectButton;

    [Header("Turn Bools")]
    public bool yourTurn;
    public bool moveMade1;
    public bool moveMade2;

    [Header("Animator")]
    public Animator player1Turn;
    public Animator player2Turn;

    //other
    public int selected = 0;
    public Text mochiText;

    [Header("Audio")]
    public AudioSource wrongAudio;
    public AudioSource actionAudio;

    [Header("Player Tog")]
    public Toggle invplayer1Toggle;
    public Toggle invplayer2Toggle;

    // Start is called before the first frame update
    void Start()
    {
        //setup game
        current = this;
        yourTurn = true;
        moveMade1 = false;
        moveMade2 = false;

        //set all text to 0
        foreach (Text i in p1IngCount)
        {
            i.text = "0";
        }

        foreach (Text i in p2IngCount)
        {
            i.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //turn-base structure
        if (yourTurn == true)
        {
            //player 1
            if (moveMade1 == true)
            {
                //Debug.Log("you moved");
                yourTurn = false;
                moveMade1 = false;
                player2Turn.SetTrigger("popUp");
                invplayer1Toggle.isOn = false;
                invplayer2Toggle.isOn = true;
                turnIndicator.text = "P2";
            }
        }
        else
        {
            //player 2  
            if (moveMade2 == true)
            {
                //Debug.Log("opponent moved");
                yourTurn = true;
                moveMade2 = false;
                player1Turn.SetTrigger("popUp");
                invplayer2Toggle.isOn = false;
                invplayer1Toggle.isOn = true;
                turnIndicator.text = "P1";
            }
        }
        //Debug.Log(yourTurn);
        //yourTurn = true;
    }

    //when button is pressed, pass into correct parameters to update correct player's ingredient inventory
    public void SelectButtonPressed()
    {
        if (yourTurn == true)
        {
            //if p1 ingredients are selected, your move was made
            bool result = SelectIngredients(player1, p1IngCount);
            if (result)
            {
                moveMade1 = true;
            }
        }
        else
        {
            //if p2 ingredients are selected, their move was made
            bool result = SelectIngredients(player2, p2IngCount);
            if (result)
            {
                moveMade2 = true;
            }
        }
    }

    //this function updates selected ingredients into respective player's inventory
    public bool SelectIngredients(Player play, Text[] ingredientCountList)
    {
        selected = 0;

        //check what ingredient toggles were selected
        Toggle[] ingToggles = ingredientGroup.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < ingToggles.Length; i++)
        {
            //if tog is on, check if player selected over 3 ingredients (illegal move)
            if (ingToggles[i].isOn)
            {
                selected += 1;
                if (selected >= 4)
                {
                    wrongAudio.Play();
                    mochiText.text = "Slow down little chef! You can only select 3 or 1 ingredient card each turn.";
                    return false;
                }
            }
        }

        //if 3 ingredients are selected, add to inventory and update ui text
        if (selected == 3)
        {
            actionAudio.Play();
            for (int i = 0; i < ingToggles.Length; i++)
            {
                if (ingToggles[i].isOn)
                {
                    play.selectIngredients(i);
                    ingredientCountList[i].text = play.ingredientDict[i].ToString();
                }
            }
            mochiText.text = "3 ingredients added to your inventory!";
        } else if (selected == 2) //if 2 selected, prompt that either 1 or 3 should be selected
        {
            wrongAudio.Play();
            mochiText.text = "Hmmm...you only selected 2. Pick 3 or 1 ingredient!";
            return false;
        } else if (selected == 1) //if 1 selected, add 2 of that ingredient to the inventory and update ui text
        {
            actionAudio.Play();
            for (int i = 0; i < ingToggles.Length; i++)
            {
                if (ingToggles[i].isOn)
                {
                    play.selectIngredients(i);
                    play.selectIngredients(i);
                    ingredientCountList[i].text = play.ingredientDict[i].ToString();
                }
            }
            mochiText.text = "2 of the same ingredient added to your inventory!";
        }

        //deselect all toggles (reset for next turn)
        for (int i = 0; i < ingToggles.Length; i++)
        {
            ingToggles[i].isOn = false;
        }
        selected = 0;
        return true;
    }

    //when button is pressed, pass into correct parameters to update correct player's recipe inventory
    public void PurchaseButtonPressed()
    {
        if (yourTurn == true)
        {
            //if purchase is legal, turn is made
            bool result = Purchase(player1, p1IngCount);
            if (result)
            {
                moveMade1 = true;
            }
        }
        else
        {
            bool result = Purchase(player2, p2IngCount);
            if (result)
            {
                moveMade2 = true;
            }
        }
    }

    //this function updates selected recipe into respective player's inventory if applicable
    public bool Purchase(Player play, Text[] ingredientCountList)
    {
        //validate that only 1 recipe is selected
        selected = 0;
        Toggle[] recipeToggles = recipeGroup.GetComponentsInChildren<Toggle>();
        foreach (Toggle t in recipeToggles)
        {
            if (t.isOn)
            {
                selected += 1;
                if (selected > 1)
                {
                    mochiText.text = "You can only purchase ONE recipe each turn!";
                    return false;
                }
            }
        }

        //if only 1 is selected, check if player has enough ingredients to buy recipe
        if (selected == 1)
        {
            foreach (Toggle t in recipeToggles)
            {
                if (t.isOn)
                {
                    if(!t.GetComponent<Recipe>().BuyRecipe(play, ingredientCountList, t))
                    {
                        return false;
                    }
                }
                else
                {
                    Debug.Log("Can't find anything.");
                }
            }
        }

        //deselect all recipe toggles to reset for next turn
        foreach (Toggle t in recipeToggles)
        {
            t.isOn = false;
        }
        selected = 0;
        return true;
    }

    //general function to update player's UI text by looking at dictionary
    public void UpdateIngredientCount(Player play, Text[] ingredientCountList)
    {
        for (int i = 0; i < 9; i++)
        {
            ingredientCountList[i].text = play.ingredientDict[i].ToString();
            if (i == 9)
            {
                ingredientCountList[i].text = (play.ingredientDict[i] + play.ingredientDict[i + 1]).ToString();
            }
        }
    }
}
