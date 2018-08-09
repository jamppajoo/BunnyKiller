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
    private GameObject blood;

    private GameObject gameController;
    private float suicideTime;
    private bool suicideActivated=false;
    private GameObject deathBunnies;
    private GameObject aliveBunnies;
    private GameObject wavecontroller;

    // Use this for initialization
    void Start ()
	{
        deathBunnies = GameObject.Find("Bodies");
        aliveBunnies = GameObject.Find("Enemies");
        wavecontroller = GameObject.Find("WaveController");
        bloodParticleSystem = GetComponentInChildren<ParticleSystem>();
		bunnyRB = GetComponentInParent<Rigidbody>();
        head = this.gameObject.transform.GetChild(1).GetChild(1).gameObject;
        body = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        gameController = GameObject.Find("GameController");

        if (this.gameObject.transform.GetChild(0).gameObject.name.Equals("bunbun")) bunbun = this.gameObject.transform.GetChild(0).gameObject;
        if (this.gameObject.transform.GetChild(2).gameObject.name.Equals("BunnyLimbz"))
        {
            bodyParts = this.gameObject.transform.GetChild(2).gameObject;
            bodyParts.SetActive(false);
        }
        if (this.gameObject.transform.GetChild(3).gameObject.name.Equals("FXHolder")) blood = this.gameObject.transform.GetChild(3).gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //when time is up, kill all the bunnies
        if (suicideActivated && suicideTime < 0 && alive)
        {
            transform.parent = deathBunnies.transform;

            health -= 1000;
            Collision hitt = null;
            this.gameObject.GetComponentInChildren<ParticleSpawner>().spillBlood(hitt);
            Explode();
        }
        else if (suicideActivated && alive) suicideTime -= Time.deltaTime;

        if (deathBunnies.transform.childCount > 10)
        {
            Destroy(deathBunnies.transform.GetChild(0).gameObject);
        }
    }

    public void Hit(float power, float maxPower)
    {
        if (power < maxPower) health -= power;
        else health -= maxPower;

        checkDeath();
    }

    public void BaseballHit(float power)
	{
        if (power < 6) health -= 10f;
        else if(power > 16) health -= 200f;
        else health -= 34f;
        
        checkDeath();
    }

	public void ScytheHit(float power)
	{
		health -= power;
        checkDeath();
	}

    public void Suicide(float time)
    {
        suicideTime = time;
        suicideActivated = true;
    }

    private void checkDeath()
    {
        if (health < 0)
        {
            if (alive) addDeath();
            if (transform.parent.name.ToString().Equals("Enemies"))
            {
                transform.parent = deathBunnies.transform;
                if (deathBunnies.transform.childCount > 10)
                {
                    Destroy(deathBunnies.transform.GetChild(0));
                }
                else print(deathBunnies.transform.childCount);
            }

            if (health < -100)
            {
                Explode();
            }
            else Die();
        }
    }

    public void addDeath()
    {
        gameController.GetComponent<GameProgression>().addKill();
    }
	public void Die()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
        this.GetComponent<Rigidbody>().AddForce(transform.up * 60f);

        alive = false;
        if(aliveBunnies.transform.childCount==0)
        {
            //all bunnies has died, end wave
            wavecontroller.GetComponent<WaveController>().WaveEnded();
        }
    }
    public void Explode()
    {
        alive = false;
        bunbun.SetActive(false);
        bodyParts.SetActive(true);
        bodyParts.transform.parent = deathBunnies.transform;
        blood.transform.parent = bodyParts.transform;
        
        Destroy(bunbun.gameObject.transform.parent.gameObject);
    }
}
