using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    void Start()
    {
        if (backgroundMusic != null)
            AudioSource.PlayClipAtPoint(backgroundMusic, Vector3.zero);
    }
}
