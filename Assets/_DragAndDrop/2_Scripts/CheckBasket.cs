using UnityEngine;

public class CheckBasket : MonoBehaviour
{
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(this.tag))

            Debug.Log("Correct");
        else
            Debug.Log("Incorrect");

        other.GetComponent<Rigidbody>().useGravity = false;
    }
*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(this.tag))
        {
            Debug.Log("Correct");
            other.gameObject.GetComponent<DragFruit>().isCorrectBasket = true;
        }
        else
            Debug.Log("Incorrect");

    }

}
