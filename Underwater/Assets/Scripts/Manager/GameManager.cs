using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Components
    #endregion

    #region Stats
    float timer = 3000f;
    public bool isFinish;
    public bool isReachTreasure;
    public bool isWin;
    public bool isStart;
    #endregion

    public static GameManager InsGameManager;

    private void Awake()
    {
        isStart = false;
        isFinish = false;
        isWin = false;
        isReachTreasure = false;
        if (InsGameManager == null) InsGameManager = this;
        Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (!isFinish)
        {
            CheckFinish();
        }
    }

    void FixedUpdate()
    {
        if (isFinish) return;
        timer -= Time.deltaTime * 50f;
    }

    void CheckFinish()
    {
        if (timer <= 0)
        {
            isWin = true;
            Endgame();
        }

        if (isReachTreasure)
        {
            isWin = false;
            Endgame();
        }
    }

    public float GetTimer()
    {
        return timer * 0.02f;
    }

    void Endgame()
    {
        isFinish = true;
        UIManager.InsUIManager.SetEndgamePanel();
    }
}
