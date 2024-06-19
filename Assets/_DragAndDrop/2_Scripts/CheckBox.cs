using UnityEngine;
using UnityEngine.EventSystems;

public class CheckBox : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragToy dragToy = dropped.GetComponent<DragToy>();
        if (dropped.CompareTag(tag))
        {
            dragToy.parentAfterDrag = transform;
        }
        else
        {
            dragToy.transform.position = dragToy.initialPosition;
        }
    }
}
