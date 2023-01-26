using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;

    [Header("Transition")]
    [SerializeField] private Canvas fadeCanvas;
    [SerializeField] private Image curtain;

    [Header("Pause")]
    [SerializeField] private GameObject pauseCanvas;

    [Header("Controls")]
    [SerializeField] private GameObject controlsCanvas;
    private bool isInControls;

    private void Awake()
    {
        if (!sharedInstance) sharedInstance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        curtain.DOFade(0, 2).OnComplete(() => fadeCanvas.enabled = false);
    }

    public void ShowPauseMenu(bool showMenu)
    {
        if (isInControls) return;

        pauseCanvas.SetActive(showMenu);
        Time.timeScale = showMenu ? 0 : 1;

        if (!showMenu)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void ShowControlsMenu(bool showControls)
    {
        pauseCanvas.SetActive(!showControls);
        controlsCanvas.SetActive(showControls);

        isInControls = showControls;
    }

    public void FinishGame()
    {
        fadeCanvas.enabled = true;
        curtain.DOFade(1, 2).OnComplete(() => SceneManager.LoadScene("FinalScene"));
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
