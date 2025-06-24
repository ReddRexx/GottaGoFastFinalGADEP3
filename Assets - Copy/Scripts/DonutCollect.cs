using UnityEngine;

public class DonutCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        LevelMInfo.donutCount += 1;
    }
}
