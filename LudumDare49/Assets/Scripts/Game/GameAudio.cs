using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class GameAudio : MonoBehaviour
    {
        public AudioSource asMusic;
        public AudioSource asSounds;

        public AudioClip music;

        public AudioClip burnSound;
        public AudioClip jumpSound;
        public AudioClip landSound;

        public void PlayBurnSound()
        {
            asSounds.PlayOneShot(burnSound);
        }

        public void PlayJumpSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(jumpSound, baseVolume: 0.1f);
        }

        public void PlayLandSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(landSound);
        }
    }
}