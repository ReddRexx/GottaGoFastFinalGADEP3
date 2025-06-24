using UnityEngine;

public class Collect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        LevelMInfo.coinCount += 1;
    }
}
