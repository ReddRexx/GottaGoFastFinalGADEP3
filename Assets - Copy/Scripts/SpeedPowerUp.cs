using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedIncreaseNum = 15;
    [SerializeField] private float powerUpTime = 5;
    [SerializeField] GameObject artDisabler = null;
    private Collider Collider;

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if(player != null )
        {
            //power up active
            StartCoroutine(PowerUpGo(player));
        }

    }

    public IEnumerator PowerUpGo(PlayerMovement player)
    {
        Collider.enabled = false;
        artDisabler.SetActive(false);

        ActivatePowerUp(player);

        yield return new WaitForSeconds(powerUpTime);

        DeactivatePowerUp(player);

        Destroy(gameObject);
    }

    private void ActivatePowerUp(PlayerMovement player)
    {
        player.SetMoveSpeed(speedIncreaseNum);
        player.SetBoosters(true);
    }

    private void DeactivatePowerUp(PlayerMovement player)
    {
        player.SetMoveSpeed(- speedIncreaseNum); 
        player.SetBoosters(false);
    }

}
