using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float horizontalSpeed = 11;
    public float rightLimit = 6;
    public float leftLimit = -6;

    [SerializeField] private TrailRenderer trail;



    private void Awake()
    {
        trail.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime *playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }

    public void SetMoveSpeed(float newSpeedAdjustment)
    {
        playerSpeed += newSpeedAdjustment;
    }

    public void SetBoosters(bool activeState)
    {
        trail.enabled = activeState;
    }
}
