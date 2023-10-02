using UnityEngine;

public class Enemigo : Health
{
    public Transform player;
    public GameObject balaPrefab;
    
    private float LastShoot;
    public Animator anim;
    public bool atacando;


    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        AnimatorControllers();
        if (player == null) return;
        Flip();
        Attack();

    }

    private void Attack()
    {
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            atacando = true;
            Shoot();
            LastShoot = Time.time;
        }
      if(distance>1.0f)
        {
            atacando = false;
        }
    }

    private void Flip()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.1380816f, 0.1380816f, 0.1380816f);
        else transform.localScale = new Vector3(-0.1380816f, 0.1380816f, 0.1380816f);
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bala = Instantiate(balaPrefab, transform.position + direction * 2, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }
    public void Hit()
    {
        currentHealth -= 10;
        if (currentHealth == 0) {
            GameManager.Instance.AddScore();
            Destroy(gameObject); 
        }
    }
    public void AnimatorControllers()
    {
        anim.SetBool("atacando", atacando);
    }
}
