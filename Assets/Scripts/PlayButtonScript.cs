using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayButtonScript : MonoBehaviour{

    public GameObject bonusButton;

	public void PlayScene() {
        SceneManager.LoadScene(1);
    }

    public void GoMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void PlayBonusLevel() {
        SceneManager.LoadScene("BonusLevel");
    }

    void Update()
    {
        if (Input.inputString.ToLower().Equals("b")) {
            StartCoroutine("MakeMagicButtonAppear");
        }
    }

    IEnumerator MakeMagicButtonAppear() {
        yield return new WaitForSeconds(5);
        if (Input.inputString.ToLower().Equals("b"))
        {
            bonusButton.SetActive(true);
        }
    }
}
