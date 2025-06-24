using UnityEngine;

public class LevelMInfo : MonoBehaviour
{

    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;

    public static int donutCount = 0;
    [SerializeField] GameObject donutDisplay;
    

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "GOLD COINS: " + coinCount;
        donutDisplay.GetComponent<TMPro.TMP_Text>().text = "Donuts: " + donutCount;
    }
}
