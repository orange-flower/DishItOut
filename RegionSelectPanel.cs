using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelectPanel : MonoBehaviour
{
    public Animator selectAnim;
    public string animTrig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //originally intended to play region selection panel but is a general function that opens and closes animations
    public void openPanel()
    {
        selectAnim.SetBool(animTrig, true);
    }

    public void closePanel()
    {
        selectAnim.SetBool(animTrig, false);
    }
}
