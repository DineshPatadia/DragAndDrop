using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToy : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]Image image;

    [HideInInspector]
    public Transform parentAfterDrag;

    Transform rootParent;

    public Vector3 initialPosition;

    private void Start()
    {
        rootParent = GameObject.Find("GameRoomBG").transform;
        initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(rootParent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }
}
