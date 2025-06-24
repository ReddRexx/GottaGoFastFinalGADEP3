using UnityEngine;

public class CollectibleRotatte : MonoBehaviour
{
    [SerializeField] int rotationSpeed = 1;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}
