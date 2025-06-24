using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegGenerator : MonoBehaviour
{
    public GameObject[] segment;
    

    [SerializeField] public int zPos = 50;
    [SerializeField] int segmentNum;
    [SerializeField] bool creatingSegmant = false;
    

    
    void Update()
    {
        if (creatingSegmant == false)
        {
            creatingSegmant = true;
            StartCoroutine(SegmentGenerator());
        }
        
    }

    IEnumerator SegmentGenerator()
    {
        segmentNum = Random.Range(0, 3);
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(1);
        creatingSegmant = false;
    }

}
