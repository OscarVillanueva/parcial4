using UnityEngine;
using UnityEngine.UI;

public class ControlsMenuController : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.Select();
    }

    public void GoBack()
    {
        UIManager.sharedInstance.ShowControlsMenu(false);
    }
}
