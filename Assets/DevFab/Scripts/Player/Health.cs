//https://www.youtube.com/watch?v=uytdBD7xDrc Como hacer una BARRA de VIDA en Unity.
using UnityEngine.UI;
using UnityEngine;


public class Health : MonoBehaviour
{
    public Image slideHealth;
    public float currentHealth;
    public float maxHealth;
    public bool estaMuerto=false;

    protected virtual void Update()
    {
 
        slideHealth.fillAmount = currentHealth / maxHealth;    
    }

}
