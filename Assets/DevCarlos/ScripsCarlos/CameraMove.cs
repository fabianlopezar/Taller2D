/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andr�s Garz�n Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicol�s Ram�rez Arango 2195824
 */
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Player.transform.position.x;
        transform.position = position;
        Vector3 position2 = transform.position;
        position2.y = Player.transform.position.y;
        transform.position = position2;
    }
}
