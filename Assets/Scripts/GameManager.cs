using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager singleton;

    public static GameManager Instance {
    get {
            if (singleton == null) { 
                singleton = Instantiate(new GameObject().AddComponent<GameManager>());
            }
            return singleton;
            
        }
    }

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene("TestLevel");
		}
	}

    public void Win() {
        Debug.Log("VICTORY½");
    }

}
