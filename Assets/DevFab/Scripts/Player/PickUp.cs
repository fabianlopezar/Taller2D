using UnityEngine;
public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema1"))
        {
            GameManager.Instance.AddGema("gema1");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Gema2"))
        {
            GameManager.Instance.AddGema("gema2");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Gema3"))
        {
            GameManager.Instance.AddGema("gema3");
            Destroy(other.gameObject);
        }
       
    }
}
