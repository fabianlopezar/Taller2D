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
