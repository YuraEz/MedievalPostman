using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioActivateTrigger : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        private void OnEnable()
        {
            try
            {
                ServiceLocator.GetService<AudioManager>().PlaySound(clip);
            }
            catch
            {

            }
        }
    }
}