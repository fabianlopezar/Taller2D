/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;

public class PlayerAnimsEvents : MonoBehaviour
{
    private Player player;
      void Start()
    {
        player=GetComponentInParent<Player>();
    }
    private void AnimationTrigger()
    {
        player.AttackOver();

    }
  
}
