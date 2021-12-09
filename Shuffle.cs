using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shuffle : MonoBehaviour
{
    [Header("Recipe Tier Toggle Lists")]
    public Recipe[] tier1Toggles;
    public Recipe[] tier2Toggles;
    public Recipe[] tier3Toggles;

    [Header("Recipe Scriptable Objs Lists")]
    public RecipeInfo[] tier1Recipes;
    public RecipeInfo[] tier2Recipes;
    public RecipeInfo[] tier3Recipes;


    // Start is called before the first frame update
    void Start()
    {
        //shuffe each tier of recipes
        ShuffleAllCards(tier1Toggles, tier1Recipes, 2);
        ShuffleAllCards(tier2Toggles, tier2Recipes, 3);
        ShuffleAllCards(tier3Toggles, tier3Recipes, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //general function that takes in a tier of toggles and its respective recipes to shuffle
    public void ShuffleAllCards(Recipe[] tierList, RecipeInfo[] recipeList, int totalCards)
    {
        foreach (Recipe tog in tierList)
        {
            int randomRecipe = Random.Range(0, totalCards);
            tog.infoScript = recipeList[randomRecipe];
        }
    }

    //general function to replace the old card with a new one
    public void ReplaceCard(Recipe togRecipe, int tier)
    {
        if (tier == 1)
        {
            int randomRecipe = Random.Range(0, 2);
            togRecipe.infoScript = tier1Recipes[randomRecipe];
            Debug.Log("Changed to " + tier1Recipes[randomRecipe].name);
        }
        else if (tier == 2)
        {
            int randomRecipe = Random.Range(0, 3);
            togRecipe.infoScript = tier2Recipes[randomRecipe];
            Debug.Log("Changed to " + tier2Recipes[randomRecipe].name);
        }
        else if (tier == 3)
        {
            int randomRecipe = Random.Range(0, 3);
            togRecipe.infoScript = tier3Recipes[randomRecipe];
            Debug.Log("Changed to " + tier3Recipes[randomRecipe].name);
        }

        togRecipe.UpdateCardToggle();
    }
}
