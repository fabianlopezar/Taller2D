using UnityEngine;

public class BalaScript : MonoBehaviour
{

    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;


    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyBullet", 2.0f);
     //   Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemigo enemigo = other.GetComponent<Enemigo>();
        Player player = other.GetComponent<Player>();
        if (enemigo != null)
        {
            enemigo.Hit();
            DestroyBullet();
        }
        if (player != null && player.estaMuerto==false)
        {
            player.Hit();
            DestroyBullet();
        }
  
    }
}
