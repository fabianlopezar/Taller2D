using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.x = player.position.x;
            position.y = player.position.y;
            transform.position = position;
        }
        else
        {
            Debug.Log("Error en: `CameraScrtipt` deberia asignarle valor a la variable player.");
        }
    }
}
