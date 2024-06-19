using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField]
    AudioSource bgMusicSFX, wrongBasketSFX, gameoverSFX, correctBasketSFX;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnEnable()
    {
        CheckBasket.wrongBasket += WrongBasketSFX;
        DragDropGameManager.addStar += PlayAddStarSFX;
        DragDropGameManager.onGameOver += PlayGameOverSFX;
    }


    private void OnDisable()
    {
        CheckBasket.wrongBasket -= WrongBasketSFX;
        DragDropGameManager.addStar -= PlayAddStarSFX;
        DragDropGameManager.onGameOver -= PlayGameOverSFX;
    }


    void WrongBasketSFX()
    {
        wrongBasketSFX.Play();
    }

    void PlayAddStarSFX()
    {
        correctBasketSFX.Play();
    }

    private void PlayGameOverSFX()
    {
        gameoverSFX.Play();
    }

    public void EnableSFX()
    {
        bgMusicSFX.volume = 1;
        wrongBasketSFX.volume = 1;
        gameoverSFX.volume = 1;
        correctBasketSFX.volume = 1;
    }

    public void DisableSFX()
    {
        bgMusicSFX.volume = 0;
        wrongBasketSFX.volume = 0;
        gameoverSFX.volume = 0;
        correctBasketSFX.volume = 0;
    }
}
