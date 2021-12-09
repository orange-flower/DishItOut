using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public Animator loadAnim;
    public string sceneName;
    public Slider loadBar;
    public GameObject videoPlayer;
    private UnityEngine.Video.VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        vp = videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadRegion(string region)
    {
        StartCoroutine(loading());
    }

    //play loading screen animation and load scene
    IEnumerator loading()
    {
        loadAnim.SetTrigger("doLoad");
        vp.Play();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }
}
