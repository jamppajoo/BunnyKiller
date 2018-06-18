using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtSystem : MonoBehaviour
{

	public ParticleSystem bloodParticleSystem;
    public float health = 100;

	public List<GameObject> bluntWeapons;
	public List<GameObject> bladeWeapons;
	private AudioSource audioSource;

	public Rigidbody bunnyRB;
    public bool alive = true;

	// Use this for initialization
	void Start ()
	{
		bloodParticleSystem = GetComponentInChildren<ParticleSystem>();
		bunnyRB = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BaseballHit(float power)
	{
		if (power < 6) health -= 10f;
        else if(power > 16) health -= 200f;
        else health -= 34f;

		if (health < 0)
		{
			if (health < -50)
			{
				Explode();
			}
			else Die();
		}
	}

	public void ScytheHit(float power)
	{
		health -= 1001f;// power;
		if (health < 0)
		{
			if (health < -1000)
			{
				print("Bunny died at ones!!!");
				Die();
			}
			else if (health < -50)
			{
				Explode();
				Die();
			}
			else Die();
		}
	}

	public void Die()
    {
        alive = false;
        print("Bunny died!");
        //Destroy(gameObject);
    }
    public void Explode()
    {
        alive = false;
        print("Bunny Explodes");
    }

	//void OnCollisionEnter(Collision hitCollision)
	//{
	//	if (bluntWeapons.Contains(hitCollision.gameObject))
	//	{
	//		ContactPoint contactPoint = hitCollision.contacts[0];
	//		Vector3 direction = contactPoint.point - transform.position;
	//		direction = -direction.normalized;
	//		Debug.Log(direction + " Direction Vector");
	//		bunnyRB.AddForce(direction * 3f, ForceMode.Impulse);
	//	}
	//	else if (bladeWeapons.Contains(hitCollision.gameObject))
	//	{

	//	}
	//	else
	//	{
	//		Debug.Log("Object not in either list :D");
	//	}
	//}
}
