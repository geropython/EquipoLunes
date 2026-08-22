using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //Escuela Player
        if (other.CompareTag("Player") && tag == "TriggerSchool")
        {
            Debug.Log("Entraste a la Escuela.");
            SceneManager.LoadScene("Escuela");
        }
        //Casa Player
        if (other.CompareTag("Player") && tag == "TriggerHouse")
        {
            Debug.Log("Entraste a la Casa.");
            SceneManager.LoadScene("Casa");
        }
    }
}
