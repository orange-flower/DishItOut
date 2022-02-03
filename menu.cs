using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public GameObject menuObject;
    public Toggle menuToggle;
    public Button mainMenu;
    public Button exit;
    public Slider volume;
    public GameObject music;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        menuToggle.isOn = false;
        menuObject.SetActive(false);
        volume.value = 1;
        mainMenu.onClick.AddListener(home);
        exit.onClick.AddListener(quit);
    }

    // Update is called once per frame
    void Update()
    {
        openMenu();
    }

    public void home()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void openMenu()
    {
        if (menuToggle.isOn == true)
        {
            menuObject.SetActive(true);
            audio = music.GetComponent<AudioSource>();
            audio.volume = volume.value;
        }
        else
        {
            menuObject.SetActive(false);
        }
    }
}
