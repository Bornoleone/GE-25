//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioTools
{
    // script for controlling the main music and doing a transition between two different snapshots and playing a transition time "step sound"
    public class MusicControlScript : MonoBehaviour
    {
        public AudioSource[] sourceOfMusic;

        public AudioMixerSnapshot DefaultSnapshot;
        // Volume snapshot for the basic ground area
        public AudioMixerSnapshot TransitionedSnapshot;
        // Volume snapshot for the red ground area
        public AudioClip[] m_TransitionEffects;
        // Array of transition step audio clips (remember to add the size and clips in the Unity editor)
        public AudioSource m_TransitionEffectSource;
        // Audio audioSourceOfThisObject for playing the Transition Steps
        public float bpm = 128;
        // Beats per minute (tempo)
    
        private float m_TransitionIn;
        private float m_TransitionOut;
        private float m_QuarterNote;

        private int currentClipIndex = 0;//index if using to play clips in order

        // Use this for initialization
        // Define the lengths of Quarter note and transitions (in and out)
        void Start()
        {
            m_QuarterNote = 60 / bpm;
            m_TransitionIn = m_QuarterNote * 2;
            m_TransitionOut = m_QuarterNote * 5;

            sourceOfMusic = GetComponents<AudioSource>();
            foreach (AudioSource source in sourceOfMusic)
                source.Play();
            
			//DefaultSnapshot.TransitionTo(m_TransitionOut);
		}
    
        // If we hit another trigger (area) we check for certain tag and fade in correspondingly (from snapshot to another)
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
			{
				PlayTransitionStep();
				TransitionedSnapshot.TransitionTo(m_TransitionIn);
            }
        }
    
        // If we exit the trigger area, check for a certain tag and fade out correspondingly (from snapshot to another)
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
			{
				PlayTransitionStep();
				DefaultSnapshot.TransitionTo(m_TransitionOut);
			}
        }
    
        // Play random Transition step audio from the selected steps 
        /*
        void PlayTransitionStep()
        {
            int randClip = Random.Range(0, m_TransitionEffects.Length);
            m_TransitionEffectSource.clip = m_TransitionEffects[randClip];
            m_TransitionEffectSource.Play();
        }*/

        // Play Transition step audio from the selected steps in order of elements
        void PlayTransitionStep()
        {
            int randClip = Random.Range(0, m_TransitionEffects.Length);
            m_TransitionEffectSource.clip = m_TransitionEffects[currentClipIndex];
            m_TransitionEffectSource.Play();
            currentClipIndex++;
        }
    }
}