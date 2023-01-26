using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startGameBtnContainer;
    [SerializeField] private TMP_Text startGameBtn;
    [SerializeField] private Image curtain;

    private void Start()
    {
        Invoke(nameof(FadeInStartButton), 5);
    }

    private void FadeInStartButton()
    {
        startGameBtn.DOFade(1, 1)
            .OnComplete(() => {
                startGameBtnContainer.interactable = true;
            });
    }

    public void StartGame()
    {
        curtain.enabled = true;
        curtain.DOFade(1, 2)
               .OnStart(() => {
                   print("Fade out iniciado");
               })
               .OnComplete(() => SceneManager.LoadScene("GameScene"));
        
    }
}
