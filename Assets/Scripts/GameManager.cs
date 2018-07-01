using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameObject singleton = null;

    public int wons = 0;

    public static GameObject Instance {
    get {
            if (singleton == null) {
                singleton = new GameObject("GameManager");
                singleton.AddComponent<GameManager>();
                DontDestroyOnLoad(singleton);
            }
            return singleton;
            
        }
    }

    public void Win() {
        Debug.Log("VICTORY½");
        wons++;
    }

}
