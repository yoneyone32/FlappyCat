using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject textScore;
    public GameObject textInfo;
    public GameObject btnRetry;

    public BlockManager blockmng;

    float startTimer;

    enum MODE
    {
        NONE,
        READY,
        MAIN,
        RESULT
    }

    MODE nowMode, nextMode;

    void Start()
    {
        startTimer = 3.9f;

        textInfo.SetActive(true);
        btnRetry.SetActive(false);

        player.GetComponent<Rigidbody2D>().simulated = false;

        nowMode = MODE.READY;
        nextMode = MODE.NONE;
    }

    void Update()
    {
        if(nowMode == MODE.READY)
        {
            startTimer -= Time.deltaTime;

            textInfo.GetComponent<Text>().text = ""+Mathf.Floor(startTimer);

            if(startTimer < 1)
            {
                textInfo.GetComponent<Text>().text = "START";
            }

            if(startTimer < 0)
            {
                player.GetComponent<Rigidbody2D>().simulated = true;
                blockmng.isStop = false;
                textInfo.SetActive(false);
                nextMode = MODE.MAIN;
            }
        }
        else if (nowMode == MODE.MAIN)
        {
            textScore.GetComponent<Text>().text = ""+ Mathf.Floor(blockmng.totalTimer);
            if(player == null)
            {
                textInfo.GetComponent<Text>().text = "GAME OVER";
                textInfo.SetActive(true);

                btnRetry.SetActive(true);
                nextMode = MODE.RESULT;
            }
        }

        if (nextMode != MODE.NONE)
        {
            nowMode = nextMode;
            nextMode = MODE.NONE;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
