using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //the player class is for managing each player's cards
    [Header("Ingredients")]
    public GameObject ing1;
    public GameObject ing2;
    public GameObject ing3;
    public GameObject ing4;
    public GameObject ing5;
    public GameObject ing6;
    public GameObject ing7;
    public GameObject ing8;
    public GameObject ing9;

    [Header("Dictionaries")]
    public Dictionary<int, int> ingredientDict = new Dictionary<int, int>();
    public Dictionary<GameObject, int> recipeDict = new Dictionary<GameObject, int>();

    [Header("Other")]
    public int score;
    public int numRecipes;

    // Start is called before the first frame update
    void Start()
    {
        //setup
        score = 0;
        numRecipes = 0;

        ingredientDict[0] = 0;
        ingredientDict[1] = 0;
        ingredientDict[2] = 0;
        ingredientDict[3] = 0;
        ingredientDict[4] = 0;
        ingredientDict[5] = 0;
        ingredientDict[6] = 0;
        ingredientDict[7] = 0;
        ingredientDict[8] = 0;
        ingredientDict[9] = 0; //for dough / tortilla
        ingredientDict[10] = 0; //for soup
    }

    // Update is called once per frame
    void Update()
    {

    }

    //dict.Add(key, value) to add values to dictionary
    public void buyRecipe(GameObject card)
    {
        //but if they buy a duplicate, it will not update to two
        //maybe we should make a dictionary with all keys define and just update value
        recipeDict.Add(card, 1);
    }

    //takes in the card index and adds to the total quantity
    public void selectIngredients(int card)
    {
        ingredientDict[card] += 1;
        //Debug.Log("Card val:" + ingredientDict[card]);
    }

    //dictionary method for checking ingredients
    public void containsIngredient(int card)
    {
        if (ingredientDict.ContainsKey(card) == true)
        {
            Debug.Log("Key is found.");
        }
        else
        {
            Debug.Log("Key is not found.");
        }
    }

    //dictionary method for checking recipe
    public void containsRecipe(GameObject card)
    {
        if (recipeDict.ContainsKey(card) == true)
        {
            Debug.Log("Key is found.");
        }
        else
        {
            Debug.Log("Key is not found.");
        }
    }


}
