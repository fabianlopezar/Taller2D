using UnityEngine;
public class PickUp : MonoBehaviour

{
    public AudioClip coinSound;
    private AudioSource audioSource;
    private void Start()
    {
   
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema1"))
        {
            GameManager.Instance.AddGema("gema1");
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Gema2"))
        {
            GameManager.Instance.AddGema("gema2");
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Gema3"))
        {
            GameManager.Instance.AddGema("gema3");
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
       
    }
}
