using UnityEngine;
using System.Collections;

namespace AGP
{
	namespace AudioTools
	{
		// Script for playing a sound when the object gets hit
		public class CrashSound : MonoBehaviour
		{

			public AudioClip crashSoft;
			// audio clip for soft crash (remember to add from Unity editor)
			public AudioClip crashHard;
			// audio clip for hard crash (remember to add from Unity editor)

			private AudioSource source;
			// audio source (remember to add from Unity editor)
			[SerializeField] private float lowPitchRange = .75F;
			// pitch low range for changing the clip pitch
			[SerializeField] private float highPitchRange = 1.5F;
			// pitch high range for changing the clip pitch
			[SerializeField] private float velocityThreshold = 10F;
			// under this value the hit will play soft sound
			[SerializeField] private float velocityMultiplier = .1F;
			// hit volume multiplier
			[SerializeField] private float hardHitVolumeMultiplier = 0.5F;
			// volume for hard hits
			[SerializeField] private float softHitVolumeMultiplier = 2.5F;
			// volume for soft hits

			void Awake()
			{

				source = GetComponent<AudioSource>();
			}


			void OnCollisionEnter(Collision coll)
			{
				source.pitch = Random.Range(lowPitchRange, highPitchRange);
				float hitVol = coll.relativeVelocity.magnitude * velocityMultiplier;
				if (coll.relativeVelocity.magnitude < velocityThreshold)
				{
					source.PlayOneShot(crashSoft, hitVol * softHitVolumeMultiplier);
				}
				else
				{
					source.PlayOneShot(crashHard, hitVol * hardHitVolumeMultiplier);
				}

			}

		}
	} 
}