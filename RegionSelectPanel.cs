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

    public void openPanel()
    {
        selectAnim.SetBool(animTrig, true);
    }

    public void closePanel()
    {
        selectAnim.SetBool(animTrig, false);
    }
}
