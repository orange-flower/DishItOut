using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rules : MonoBehaviour
{
    // Start is called before the first frame update
    public Button rulesButton;
    public Button tutorialButton;
    public Button readyButton;

    public Animator rulesAnimator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openRules()
    {
        rulesAnimator.SetBool("openRules", true);
    }

    public void closeRules()
    {
        rulesAnimator.SetBool("openRules", false);
    }
}
