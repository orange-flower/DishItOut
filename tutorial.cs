using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public GameObject vid1;
    public GameObject vid2;
    public GameObject vid3;
    public GameObject vid4;
    public GameObject vid5;
    public Button tutorialButton;


    // Start is called before the first frame update
    void Start()
    {
        vid1.SetActive(false);
        vid2.SetActive(false);
        vid3.SetActive(false);
        vid4.SetActive(false);
        vid5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startVid()
    {
        vid1.SetActive(false);
        vid1.SetActive(true);
    }
    public void playVid2()
    {
        vid1.SetActive(false);
        vid2.SetActive(false);
        vid2.SetActive(true);
    }
    public void playVid3()
    {
        vid2.SetActive(false);
        vid3.SetActive(false);
        vid3.SetActive(true);
    }
    public void playVid4()
    {
        vid3.SetActive(false);
        vid4.SetActive(false);
        vid4.SetActive(true);
    }
    public void playVid5()
    {
        vid4.SetActive(false);
        vid5.SetActive(false);
        vid5.SetActive(true);
    }

    public void endTutorial()
    {
        vid5.SetActive(false);
    }
}
