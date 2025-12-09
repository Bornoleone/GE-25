using UnityEngine;
using UnityEngine.PlayerLoop;

public class UpwardsForce : MonoBehaviour
{
    public float forceAmount = 1000.0f;
    public Rigidbody targetRigidbody;
	private void Start()
	{
		targetRigidbody = GetComponent<Rigidbody>();
	}
	private void FixedUpdate()
	{
		targetRigidbody.AddForce(Vector3.up * forceAmount);
	}
}
