using UnityEngine;
using UnityEngine.EventSystems;
using static CheckBasket;

public class CheckBox : MonoBehaviour, IDropHandler
{
    public delegate void WrongBox();
    public static event WrongBox wrongBox;


    //Check if the dropped toys are correct or not If yes change position & size of the toy
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragToy dragToy = dropped.GetComponent<DragToy>();

        if (!dragToy.isCorrectBox)
        {
            if (dropped.CompareTag(tag))
            {
                dragToy.parentAfterDrag = transform;

                Vector2 pos = new Vector2(transform.position.x, transform.position.y + 38f);
                
                dropped.transform.position = pos;

                if (tag.Equals("Train") || tag.Equals("Truck"))
                    dropped.GetComponent<RectTransform>().sizeDelta = Vector2.one * 200f;
                else if(tag.Equals("Block") || tag.Equals("Lego"))
                    dropped.GetComponent<RectTransform>().sizeDelta = Vector2.one * 100f;
                else
                    dropped.GetComponent<RectTransform>().sizeDelta = Vector2.one * 150f;

                dragToy.isCorrectBox = true;

                DragDropGameManager.Instance.AddStars(transform.position);
            }
            else
            {
                dragToy.transform.position = dragToy.initialPosition;
                if (wrongBox != null)
                    wrongBox();
            }
        }
    }
}
