using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject menuPanel;
    public GameObject informationPanel;
    public AudioSource song;

    public Button playButton;
    public Button exitButton;
    public Button infoButton;
    public Button backButton;


    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (informationPanel != null)
        {
            infoButton.onClick.AddListener(Info);
            backButton.onClick.AddListener(Back);
        }

        videoPlayer.loopPointReached += OnVideoEnd;

        menuPanel.SetActive(false);

        playButton.onClick.AddListener(Play);
        exitButton.onClick.AddListener(Exit);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        song.Play();
        menuPanel.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Info()
    {
        menuPanel.SetActive(false);
        informationPanel.SetActive(true);
    }
    public void Back()
    {
        menuPanel.SetActive(true);
        informationPanel.SetActive(false);
    }
}
