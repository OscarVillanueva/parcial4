using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;

    private GameObject currentSelected;

    private void OnEnable()
    {
        buttons[0].GetComponentInChildren<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        // Compare selected gameObject with referenced Button gameObject
        if (EventSystem.current.currentSelectedGameObject != currentSelected)
        {
            currentSelected = EventSystem.current.currentSelectedGameObject;
            ChangeTextAlignment();
        }
    }

    private void ChangeTextAlignment()
    {
        foreach (GameObject btn in buttons)
        {
            TextAlignmentOptions initialAlignment = TextAlignmentOptions.Left;
            Color initialColor = new(0.784f, 0.764f, 0.717f);

            if (btn == currentSelected)
            {
                initialAlignment =  TextAlignmentOptions.Center;
                initialColor = Color.white;
            }
            
            btn.GetComponentInChildren<TMP_Text>().alignment = initialAlignment;
            btn.GetComponentInChildren<TMP_Text>().color = initialColor;
        }
    }

    public void Continue()
    {
        UIManager.sharedInstance.ShowPauseMenu(false);
    }

    public void ShowControls()
    {
        UIManager.sharedInstance.ShowControlsMenu(true);
    }

    public void ExitGame()
    {
        UIManager.sharedInstance.ExitGame();
    }
}
