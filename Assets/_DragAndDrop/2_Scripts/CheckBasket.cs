using UnityEngine;

public class CheckBasket : MonoBehaviour
{

    public delegate void WrongBasket();
    public static event WrongBasket wrongBasket;

   

    //Check if the dropped fruits are correct or not
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(other.contacts[0].point);

            if (!other.gameObject.GetComponent<DragFruit>().isCorrectBasket)
            {
                DragDropGameManager.Instance.AddStars(screenPos);

                
            }

            other.gameObject.GetComponent<DragFruit>().isCorrectBasket = true;

        }
        else
        {
            if (wrongBasket != null)
                wrongBasket();
        }
            

    }



}
