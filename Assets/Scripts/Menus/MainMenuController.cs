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
    [SerializeField] private AudioClip menuClip;
    [SerializeField] private AudioClip gameClip;

    private void Start()
    {
        MusicManager.sharedInstance.PlayMusic(menuClip);
        Invoke(nameof(FadeInStartButton), 7);
    }

    private void FadeInStartButton()
    {
        startGameBtn.DOFade(1, 2)
            .OnComplete(() => {
                startGameBtnContainer.interactable = true;
            });
    }

    public void StartGame()
    {
        curtain.enabled = true;
        curtain.DOFade(1, 2)
               .OnComplete(() => {
                   MusicManager.sharedInstance.AddToTail(gameClip);
                   SceneManager.LoadScene("GameScene");
                });
        
    }
}
