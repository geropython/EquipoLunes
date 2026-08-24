using UnityEngine;

public class Mini_map : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        transform.position = player.position + Vector3.up * 30f;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}