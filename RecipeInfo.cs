using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IngredientReq
{
    public string ingName;
    public int amount;
    public int ingIdx;
}

[System.Serializable]
[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe Card")]

public class RecipeInfo : ScriptableObject
{
    public string recipeName;
    public Sprite recipeImg;
    public string region;
    public int tier;
    public int points;

    public List<IngredientReq> ingList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
