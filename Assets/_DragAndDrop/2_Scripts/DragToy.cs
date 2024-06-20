using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToy : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]Image image;

    public bool isCorrectBox;
    public bool isParentSet;



    [HideInInspector]
    public Transform parentAfterDrag;

    Transform rootParent;

    [HideInInspector]
    public Vector3 initialPosition;

    private void Start()
    {
        DragDropGameManager.Instance.totalObjects = 21;
        rootParent = GameObject.Find("GameParent").transform;
        initialPosition = transform.position;
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isCorrectBox)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(rootParent);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isCorrectBox)
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isParentSet)
            return;

        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        if (isCorrectBox)
            isParentSet = true;

    }
}
