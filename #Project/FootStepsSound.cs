using UnityEngine;

public class FootStepsSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public bool play;
    public float delay = 1f;
    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (play)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0f;
                audioSource.Play();
            }
        }
        else
        {
            timer = 0f;
        }
    }
}
