using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    bool isEnd;
    bool isStartFirstTime;
    int score;

    private GameObject obj;
    public Text txtTitle;
    public Text txtTitle2;
    public Text txtScore;
    public GameObject pnlEndGame;
    public Text txtEndGame;
    public Button btnTryAgain;
    public Button btnExit;

    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;

    private AudioSource audioSource;
    public AudioClip gameoverClip;
    public AudioClip backgroundClip;
    public AudioClip menuBackgroundCLip;
    public AudioClip getPoint;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        Time.timeScale = 0;
        isEnd = false;
        isStartFirstTime = true;
        score = 0;

        pnlEndGame.SetActive(false);

        audioSource = obj.GetComponent<AudioSource>();
        audioSource.volume = 0.6f;
        audioSource.clip = menuBackgroundCLip;
        audioSource.Play();
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale == 0)
            {
                Time.timeScale = 1;
                audioSource.clip = backgroundClip;
                audioSource.Play();
                txtScore.text = "Score: 0";
                txtTitle.text = "";
                txtTitle.transform.position = new Vector3(20, 40);
                txtTitle2.text = "";
                txtTitle2.transform.position = new Vector3(20, 40);
            }
        }
        
    }

    public void RestartButtonClick()
    {
        btnTryAgain.GetComponent<Image>().sprite = btnClick;
    }

    public void RestartButtonHover()
    {
        btnTryAgain.GetComponent<Image>().sprite = btnHover;
    }

    public void RestartButtonExitClick()
    {
        btnExit.GetComponent<Image>().sprite = btnClick;
    }

    public void RestartButtonExitHover()
    {
        btnExit.GetComponent<Image>().sprite = btnHover;
    }

    public void RestartButtonIdle()
    {
        btnTryAgain.GetComponent<Image>().sprite = btnIdle;
        btnExit.GetComponent<Image>().sprite = btnIdle;
    }

    public void GetScore()
    {
        score++;
        txtScore.text = "Score: " + score.ToString();
        audioSource.PlayOneShot(getPoint);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        StartGame();
    }

    public void EndGame()
    {
        isEnd = true;
        isStartFirstTime = false;
        Time.timeScale = 0;

        audioSource.clip = gameoverClip;
        audioSource.Play();
        audioSource.loop = false;

        txtScore.text = "";

        pnlEndGame.SetActive(true);
        txtEndGame.text = "Your Score: " + score.ToString();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
