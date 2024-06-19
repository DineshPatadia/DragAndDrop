using System.Collections;
using TMPro;
using UnityEngine;

public class DragDropGameManager : MonoBehaviour
{
    public static DragDropGameManager Instance;


    public delegate void GameOverEvent();
    public static event GameOverEvent onGameOver;

    public delegate void CorrectBasket();
    public static event CorrectBasket addStar;

    bool isGameStarted;

    [Header("Panels")]
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject gameOverPanel;
    int totalFruits = 18;
    int currentFruits = 0;

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public int startingTime = 60;
    float currentTime;


    [Header("Points")]
    [SerializeField] Transform starsParent;
    [SerializeField] Transform pointsStar;

    [SerializeField] int points = 0;
    [SerializeField] int pointsCount = 0;

    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI gameOverPointsText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        currentTime = startingTime;
        points = 0;
        pointsCount = 0;
        isGameStarted = false;
    }

    private void Update()
    {
        if (isGameStarted)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                GameOver();
            }

            timerText.text = Mathf.FloorToInt(currentTime).ToString();
        }
    }

    public void StartGame()
    {
        tutorialPanel.SetActive(false);
        isGameStarted = true;
    }

   

    void GameOver()
    {
        gameOverPointsText.text = points.ToString();
        gameOverPanel.SetActive(true);
        isGameStarted = false;
        currentTime = startingTime;
        currentFruits = 0;

        if (onGameOver != null)
            onGameOver();
        
    }

    public void AddStars(Vector2 position)
    {
        pointsCount = points;
        pointsText.text = pointsCount.ToString();
        points += 10;
        currentFruits++;

        foreach (Transform star in starsParent.transform)
            star.gameObject.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(StartStarAnimation(position));
    }

    IEnumerator StartStarAnimation(Vector2 startValue)
    {
        float timeDuration = 1f;

        if (pointsCount > points)
            pointsCount = points;

        foreach (Transform star in starsParent.transform)
        {
            StartCoroutine(Lerp(star, startValue, pointsStar.position, timeDuration));
            star.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        foreach (Transform star in starsParent.transform)
        {
            star.gameObject.SetActive(false);
            
            yield return new WaitForSeconds(0.1f);
        }

    }

    //Animating Positions using Lerp
    IEnumerator Lerp(Transform transform, Vector2 startValue, Vector2 endValue, float timeDuration)
    {
        float timeElapsed = 0;
        float xLerp = 0;
        Vector2 initialPos = transform.position;
        Vector2 endVector = Vector2.zero;

        while (timeElapsed < timeDuration)
        {
            timeElapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(startValue, endValue, timeElapsed / timeDuration); 

            yield return null;
        }

        transform.position = endValue;

        pointsCount++;
        if (addStar != null)
            addStar();
        pointsText.text = pointsCount.ToString();

        if (currentFruits == totalFruits)
            GameOver();

    }
}
