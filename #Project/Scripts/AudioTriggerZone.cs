using UnityEngine;
using UnityEngine.Audio;

public class AudioTriggerZone : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot snapshot;
    [SerializeField] private float transitionTime = 2f;

    void OnTriggerEnter(Collider other)
    {
        snapshot.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider other)
    {
        // snapshot.TransitionTo(transitionTime);
    }
}
