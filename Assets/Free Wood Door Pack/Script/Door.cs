using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class Door : MonoBehaviour {
	bool doorStateOpen;
	public float smooth = 1.0f;
	float DoorOpenAngle = -90.0f;
    float DoorCloseAngle = 0.0f;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
	}

		private void Update()
		{
			if (doorStateOpen == true)
			{
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
            }
			else if (doorStateOpen == false)
			{
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
            }
		}


        public void Open() 
		{
			doorStateOpen = true;
			asource.clip = openDoor;
			asource.Play();

        }
		public void Close() 
		{
            doorStateOpen = false;
            asource.clip = closeDoor;
            asource.Play();
		}

    }
}