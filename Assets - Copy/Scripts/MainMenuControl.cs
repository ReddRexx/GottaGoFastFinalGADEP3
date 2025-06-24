using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOutMM;
    [SerializeField] GameObject bouncyText;
    [SerializeField] GameObject giantButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //starts level 2
        StartCoroutine(NextLevel());
    }

  

    public void StartGame()
    {
        StartCoroutine(StartButton());
        
    }

    IEnumerator StartButton()
    {
        fadeOutMM.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);

        
    }

    public void MenuStartButton()
    {
        StartCoroutine(AnimCam());
    }

    //Wait 15 seconds in main menu To start level 2 (Secret Level)
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(3);
    }

    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("MenuAnimatedCam");
        bouncyText.SetActive(false);
        giantButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControl.SetActive(true);
    }
}
