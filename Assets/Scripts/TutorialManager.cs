using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;

    private bool tutorialFinished = false;

    void Start()
    {
        tutorialPanel.SetActive(true);
    }

    void Update()
    {
        if (!tutorialFinished)
        {
            if (Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                tutorialFinished = true;

                tutorialPanel.SetActive(false);
            }
        }
    }
}
