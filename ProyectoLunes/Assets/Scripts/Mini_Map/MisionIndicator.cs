using UnityEngine;
using UnityEngine.UI;

public class MissionIndicator : MonoBehaviour
{
    public Transform player;
    public Transform target;

    public Transform icon;

    public float minimapRadius = 100f;

    void Update()
    {
        // Dirección desde el jugador hasta la misión
        Vector3 direction = target.position - player.position;

        // Ignoramos la altura
        direction.y = 0;

        float distance = direction.magnitude;

        // Posición donde queremos colocar el icono
        Vector3 iconPosition;

        if (distance > minimapRadius)
        {
            // Si está lejos, ponemos el icono en el borde
            iconPosition = player.position +
                           direction.normalized * minimapRadius;
        }
        else
        {
            // Si está dentro del rango, sigue la posición real
            iconPosition = target.position;
        }

        // Mantener el icono arriba para que lo vea la cámara del minimapa
        iconPosition.y = player.position.y + 25f;

        icon.position = iconPosition;
    }
}