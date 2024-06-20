using UnityEngine;

public class WardrobeAnimation : MonoBehaviour
{
    [SerializeField] GameObject arrowsParent, leftDoorHints, rightDoorHints;
    [SerializeField] string animationName;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DragDropGameManager.onGameStart += OpenDoorsAnimation;
    }


    private void OnDisable()
    {
        DragDropGameManager.onGameStart -= OpenDoorsAnimation;
    }

    //Trigger this once tutorial screen is closed it
    void OpenDoorsAnimation()
    {
        animator.Play(animationName);
    }

}
