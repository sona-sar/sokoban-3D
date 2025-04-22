using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;
    public AudioClip moveSound;
    public AudioClip buttonSound;

    public void PlayMoveSound()
    {
        SFXSource.PlayOneShot(moveSound);
    }
    public void PlayButtonSound()
    {
        SFXSource.PlayOneShot(buttonSound);
    }
}
