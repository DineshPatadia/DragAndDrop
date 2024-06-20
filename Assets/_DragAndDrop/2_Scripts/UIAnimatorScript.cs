using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimatorScript : MonoBehaviour
{

    [SerializeField]Transform game1Button, game2Button; 

    float startValue = 950;
    float endValue1 = -250;
    float endValue2 = 50;
    float endValue3 = 250;
    float xLerp;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }


    public void ButtonsSwipesIn()
    {
        StartCoroutine(ManageButtonsAnimation());
    }


    //Calling Lerp animations of game buttons after delays
    IEnumerator ManageButtonsAnimation()
    {
        StartCoroutine(Lerp(game1Button, startValue, endValue1,1f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Lerp(game2Button, startValue, endValue2, 0.5f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Lerp(game2Button, endValue2, endValue3, 0.5f));

        game1Button.GetComponent<Button>().interactable = true;
        game2Button.GetComponent<Button>().interactable = true;
    }

    


    //Animating Positions using Lerp
    IEnumerator Lerp(Transform transform, float startValue, float endValue,float timeDuration)
    {
        float timeElapsed = 0;
        xLerp = 0;
        Vector2 initialPos = transform.localPosition;
        Vector2 endVector = Vector2.zero;

        while (timeElapsed < timeDuration)
        {
            xLerp = Mathf.Lerp(startValue, endValue, timeElapsed / timeDuration);
            timeElapsed += Time.deltaTime;
            transform.localPosition = new Vector2(xLerp, initialPos.y);

            yield return null;
        }

        transform.localPosition = new Vector2(endValue, initialPos.y);
    }

}
