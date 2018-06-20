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

    private GameObject head;
    private GameObject body;

    private GameObject bunbun;
    private GameObject bodyParts;

    // Use this for initialization
    void Start ()
	{
		bloodParticleSystem = GetComponentInChildren<ParticleSystem>();
		bunnyRB = GetComponentInParent<Rigidbody>();
        head = this.gameObject.transform.GetChild(1).GetChild(1).gameObject;
        body = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;

        if(this.gameObject.transform.GetChild(0).gameObject.name.Equals("bunbun")) bunbun = this.gameObject.transform.GetChild(0).gameObject;
        if (this.gameObject.transform.GetChild(2).gameObject.name.Equals("BunnyLimbz"))
        {
            bodyParts = this.gameObject.transform.GetChild(2).gameObject;
            bodyParts.SetActive(false);
        }


        }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BaseballHit(float power)
	{
        //Explode();

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
        this.GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
        this.GetComponent<Rigidbody>().AddForce(transform.up * 60f);

        alive = false;
        print("Bunny died!");
        if (this.transform.localScale.z > 0.02) this.transform.localScale += new Vector3(0.01f, 0.01f, -0.01f);
        //Destroy(gameObject);
    }
    public void Explode()
    {
//        this.GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
//        this.GetComponent<Rigidbody>().AddForce(transform.up * 60f);

        alive = false;
        print("Bunny Explodes");

        bunbun.SetActive(false);
        bodyParts.SetActive(true);
       
//        head.transform.localScale += new Vector3(0.1f, 0.1f, -0.1f);
//        body.transform.localScale += new Vector3(-0.1f, 0.1f, 0.1f);
        if(this.transform.localScale.z>0.02)this.transform.localScale += new Vector3(0.01f, 0.01f, -0.01f);
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
