using UnityEngine;

public class DragFruit : MonoBehaviour
{
    [SerializeField]
    public bool isCorrectBasket;

    private Vector3 mOffset;
    private Vector3 yStatic;

    private float mZCoord;

    void OnMouseDown()
    {
        if (!isCorrectBasket)
        {
            GetComponent<Rigidbody>().useGravity = false;
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }
        //Debug.Log("Down");
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (!isCorrectBasket)
        {
            yStatic = GetMouseWorldPos() + mOffset;
            transform.position = new Vector3(yStatic.x, 2f, yStatic.z);
            //Debug.Log("Drag");
        }
    }


}
