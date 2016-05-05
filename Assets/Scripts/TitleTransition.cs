using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleTransition : MonoBehaviour
{
    public CanvasGroup options;
    public CanvasGroup main;
    public CanvasGroup controls;
    public Text soundText;
    public GameObject menuMusic;

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("House_Inside");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    public void OnOptionsButtonClicked(bool clicked)
    {
        if (clicked == true)
        {
            main.alpha = 0;
            main.blocksRaycasts = false;
            main.interactable = false;

            options.alpha = 1;
            options.blocksRaycasts = true;
            options.interactable = true;
        }
        else
        {
            options.alpha = 0;
            options.blocksRaycasts = false;
            options.interactable = false;

            main.alpha = 1;
            main.blocksRaycasts = true;
            main.interactable = true;
        }
    }

    public void OnControlsButtonClicked(bool clicked)
    {
        if(clicked == true)
        {
            controls.alpha = 1;
            controls.interactable = true;
            controls.blocksRaycasts = true;

            options.alpha = 1;
            options.blocksRaycasts = false;
            options.interactable = false;
        }
        else
        {
            controls.alpha = 0;
            controls.interactable = false;
            controls.blocksRaycasts = false;

            options.alpha = 1;
            options.blocksRaycasts = true;
            options.interactable = true;
        }
    }

    public void OnSoundButtonClicked()
    {
        if (soundText.text == "On")
        {
            menuMusic.GetComponent<AudioSource>().enabled = false;
            soundText.text = "Off";
            soundText.color = Color.black;
        }
        else if (soundText.text == "Off")
        {
            menuMusic.GetComponent<AudioSource>().enabled = true;
            soundText.text = "On";
            soundText.color = Color.yellow;
        }
    }
}
