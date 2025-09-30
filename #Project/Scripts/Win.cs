using UnityEngine;

public class Win : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("WIIIIN !!!!"); 
        }
    }
}
