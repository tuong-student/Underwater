using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNavigation : MonoBehaviour
{
    [SerializeField] GameObject NextPanel;
    [SerializeField] UnityEngine.UI.Button panelButton;
    [SerializeField] bool DeactiveWhenStart;
    [SerializeField] bool DeactiveWhenPress;

    // Start is called before the first frame update
    void Start()
    {
        panelButton.onClick.AddListener(MoveNext);
        if (DeactiveWhenStart) this.gameObject.SetActive(false);
    }

    void MoveNext()
    {
        if(DeactiveWhenPress)
            this.gameObject.SetActive(false);
        if(NextPanel)
            NextPanel.SetActive(true);

        Time.timeScale = 1f;
    }
}
