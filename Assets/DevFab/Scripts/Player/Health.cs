/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
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
