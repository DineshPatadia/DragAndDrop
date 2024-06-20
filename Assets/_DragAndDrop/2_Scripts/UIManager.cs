using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform gameParent;

    //checks the screen size & calculate the size of game parent rect of Toy sorting Game
    private void Awake()
    {
        float sHeight = Screen.height;

        float scaleMultiplier = Mathf.Clamp(sHeight / 2160f, 1f, 1.5f);

        gameParent.localScale = Vector2.one * scaleMultiplier;
    }
}
