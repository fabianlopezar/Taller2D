//https://www.youtube.com/watch?v=uytdBD7xDrc Como hacer una BARRA de VIDA en Unity.
using UnityEngine.UI;

public class Health : Entity
{
    public Image slideHealth;
    public float currentHealth;
    public float maxHealth;
    public bool estaMuerto=false;

    protected override void Update()
    {
        base.Update();
        slideHealth.fillAmount = currentHealth / maxHealth;    
    }

}
