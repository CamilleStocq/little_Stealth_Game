using UnityEngine;
using UnityEngine.Audio;

public class LowpassController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Transform target;
    [SerializeField] private float maxDistance = 5f;
    // [SerializeField] private AnimationCurve curve ;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        float freq = Mathf.Lerp(22000f, 10f, distance / maxDistance);
        // float freq = curve.Evaluate(distance);
        mixer.SetFloat("Lowpass Cutoff", freq);
    }
}
