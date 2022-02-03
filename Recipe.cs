using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    public RecipeInfo infoScript;
    public Player player1;
    public Player player2;
    public Shuffle shuffleScript;

    //alert var
    public Toggle closeAlert;
    public GameObject purchaseAlert;
    public Text p1ScoreCount;
    public Text p1RecipeCount;
    public Text p2ScoreCount;
    public Text p2RecipeCount;
    public GameObject winAlert;
    public Text P1Reusable1Count;
    public Text P1Reusable2Count;
    public Text P2Reusable1Count;
    public Text P2Reusable2Count;


    // Start is called before the first frame update
    void Start()
    {
        //make function to update card art
        UpdateCardToggle();
        
        purchaseAlert.SetActive(false);
        winAlert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (closeAlert.isOn == false)
        {
            purchaseAlert.SetActive(false);
            closeAlert.isOn = true;
        }
    }

    public void UpdateCardToggle()
    {
        GetComponentInChildren<Image>().sprite = infoScript.recipeImg;
        transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = infoScript.recipeImg;
    }

    public bool BuyRecipe(Player play, Text[] ingredientCountList, Toggle tog)
    {
        //audio
        GameObject audio = GameObject.Find("Game Manager");
        UIController audioScript = audio.GetComponent<UIController>();
        bool canBuy = true;
        foreach (IngredientReq ing in infoScript.ingList)
        {
            if (play.ingredientDict[ing.ingIdx] >= ing.amount)
            {
                //stuff here
                Debug.Log(play.ingredientDict[ing.ingIdx]);
            }
            else
            {
                canBuy = false;
                purchaseAlert.SetActive(true);
                audioScript.wrongAudio.Play();
            }
        }

        if (canBuy)
        {
            //updating Mochi text
            GameObject uiText = GameObject.Find("Game Manager");
            UIController uiControl = uiText.GetComponent<UIController>();
            //update reusable recipe
            //GameObject ingDict = GameObject.Find("Player");
            //Player playerScript = ingDict.GetComponent<Player>();
            foreach (IngredientReq ing in infoScript.ingList)
            {
                if (ing.ingIdx == 9 || ing.ingIdx == 10)
                {
                    continue;
                }
                else
                {
                    play.ingredientDict[ing.ingIdx] -= ing.amount;
                }
            }
            //pass in parameters to tell it which player text to update
            UIController.current.UpdateIngredientCount(play, ingredientCountList);
            //if (infoScript.recipeName == "Dough")
            if (infoScript.recipeName == "Dough")
            {
                audioScript.actionAudio.Play();
                play.selectIngredients(9);
                if (UIController.current.yourTurn)
                {
                    P1Reusable1Count.text = (int.Parse(P1Reusable1Count.text) + 1).ToString();
                }
                else
                {
                    P2Reusable1Count.text = (int.Parse(P2Reusable1Count.text) + 1).ToString();
                }
                uiControl.mochiText.text = "Dough is added to your inventory, you can reuse this as many times as you want!";
            }
            else if (infoScript.recipeName == "Tortilla")
            {
                audioScript.actionAudio.Play();
                play.selectIngredients(9);
                if (UIController.current.yourTurn)
                {
                    P1Reusable1Count.text = (int.Parse(P1Reusable1Count.text) + 1).ToString();
                }
                else
                {
                    P2Reusable1Count.text = (int.Parse(P2Reusable1Count.text) + 1).ToString();
                }
                uiControl.mochiText.text = "Tortilla is added to your inventory, you can reuse this as many times as you want!";
            }
            else if (infoScript.recipeName == "Soup stock")
            {
                audioScript.actionAudio.Play();
                //playerScript.ingredientDict[10] += 1;
                play.selectIngredients(10);
                if (UIController.current.yourTurn)
                {
                    P1Reusable2Count.text = (int.Parse(P1Reusable2Count.text) + 1).ToString();
                }
                else
                {
                    P2Reusable2Count.text = (int.Parse(P2Reusable2Count.text) + 1).ToString();
                }
                uiControl.mochiText.text = "Soup stock is added to your inventory, you can reuse this as many times as you want!";
            }
            else
            {
                audioScript.actionAudio.Play();
                play.score += infoScript.points;
                play.numRecipes += 1;
                //updating Mochi text
                uiControl.mochiText.text = "You go chef! One recipe added to your inventory.";
            }
            
            if(UIController.current.yourTurn)
            {
                p1ScoreCount.text = play.score.ToString();
                p1RecipeCount.text = play.numRecipes.ToString();
            }
            else
            {
                p2ScoreCount.text = play.score.ToString();
                p2RecipeCount.text = play.numRecipes.ToString();
            }

            Recipe togRecipe = tog.GetComponent<Recipe>();
            shuffleScript.ReplaceCard(togRecipe, togRecipe.infoScript.tier);
            Debug.Log("Changed recipe");

            Debug.Log("Just bought something");
            if (play.score >= 10)
            {
                winAlert.SetActive(true);
                if (audioScript.yourTurn == false) {
                    winAlert.GetComponentInChildren<Text>().text = "Congratulation! Player 2 has won.";
                } else
                {
                    winAlert.GetComponentInChildren<Text>().text = "Congratulation! Player 1 has won.";
                }
            }
            return true;
        }
        else
        {
            Debug.Log("You don't have enough ingredients");
            return false;
        }
    }
}
