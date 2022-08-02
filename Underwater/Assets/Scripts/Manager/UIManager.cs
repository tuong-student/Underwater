using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Components
    [SerializeField] TMPro.TextMeshProUGUI txtTimer, endgameText;
    [SerializeField] GameObject EndgamePanel;
    #endregion

    #region Stats
    #endregion


    public static UIManager InsUIManager;

    private void Awake()
    {
        if (InsUIManager == null) InsUIManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EndgamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        txtTimer.text = GameManager.InsGameManager.GetTimer().ToString("0.00");
    }

    public void SetEndgamePanel()
    {
        EndgamePanel.SetActive(true);
        if (GameManager.InsGameManager.isWin)
        {
            endgameText.text = "You Won";
            endgameText.color = Color.green;
        }
        else
        {
            endgameText.text = "You Lose";
            endgameText.color = Color.red;
        }
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
