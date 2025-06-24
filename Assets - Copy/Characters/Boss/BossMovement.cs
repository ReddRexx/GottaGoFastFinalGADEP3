using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // The 'Move' Section
    public float bossSpeed = 10;

    //The 'Look' section
    Transform Player;
    float distance; //Comment this out if distance not needed
    public float maxDistance;
    public Transform body;

    // The 'Shoot' section
    public GameObject projectile;

    //fire rate
    public float fireRate, nextFire;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {  
        transform.Translate(Vector3.forward * Time.deltaTime * bossSpeed, Space.World);

        distance = Vector3.Distance(Player.position, transform.position); //Comment this line out if distance not needed
        if(distance <= maxDistance)
        {
            body.LookAt(Player);
            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1f/fireRate;
                Shoot();
            }
            
        }
     
    }

    void Shoot()
    {
       GameObject clone = Instantiate(projectile, body.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * 1500); 
        Destroy(clone, 10);
        //force forward
    }
}
