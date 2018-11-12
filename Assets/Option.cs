using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour {
	public void Quit () {
		Debug.Log ("APPLICATION QUIT!");
		Application.Quit();
	}
	public void Retry () {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
