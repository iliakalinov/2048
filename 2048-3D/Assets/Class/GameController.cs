using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI thisScore;
    public TextMeshProUGUI maxScore;
    [SerializeField]
    private int step = 0;
    public TextMeshProUGUI stepText;

    public Progress progress;

    private int score = 0;
    private int maxScoreInt = 0;
    public GameObject buttonStartGame;
    public TextMeshProUGUI textPlay;

    public PlatformController PlatformController;
    public MainBox mainBox;

    public BorderEndGame BorderEndGame;

    private void Start()
    {
        progress.SetIsGame(false);
        BorderEndGame.SetCallback(EndGame);
    }

    public void ClickStarstGame()
    {
        DeleteBoxs();

        PlatformController.GenerateLevel();
        mainBox.GenerateMainBox();

        progress.SetIsGame(true);
        buttonStartGame.SetActive(false);
        maxScoreInt = progress.GetmaxCount();
        maxScore.text = "Max Score: " + maxScoreInt.ToString();//TODO
        score = 0;
        newTextThesScore(0);
        textPlay.text = "Play";

        step = -1;
        NewStep();
    }

    private void EndGame(bool states)
    {
        progress.SetIsGame(false);
        buttonStartGame.SetActive(true);
        textPlay.text = "BAD =( Play";
    }

    private void DeleteBoxs()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (GameObject box in boxes)
        {
            Destroy(box);
        }
    }
    public void NewStep()
    {
        step++;
        stepText.text = "Step:" + step.ToString();
    }

    public void NewHit(int newScore)
    {
        if (newScore == maxScoreInt)
        {
            newTextThesScore(newScore);
            progress.SetIsGame(false);
            buttonStartGame.SetActive(true);

            textPlay.text = "YOU WIN!!";
        }
        else
        {
            if (newScore > score)
            {
                score = newScore;
                newTextThesScore(score);
            }
        }
    }

    public void newTextThesScore(int score)
    {
        thisScore.text = "Score:"+score.ToString();
    }

}
