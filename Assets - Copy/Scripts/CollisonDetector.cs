using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonDetector : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeToBlack;
    [SerializeField] GameObject playerAnim;

    void OnTriggerEnter(Collider other)
    {
       StartCoroutine(CollisonEnd());
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards");
    }
    IEnumerator CollisonEnd()
    {
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        mainCam.GetComponent<Animator>().Play("collisionCam");
        yield return new WaitForSeconds(2);
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
