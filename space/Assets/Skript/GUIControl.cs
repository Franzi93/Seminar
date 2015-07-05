using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	public GameObject PauseMenu;
	private bool paused = false;
	
	// Use this for initialization
	void Start () {
		PauseMenu.SetActive(paused);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause();			
		}
	}
	public void TogglePause()
	{
		paused = !paused;
		PauseMenu.SetActive(paused);
		if(paused)
		{
			Time.timeScale=0;
		}
		else
		{
			Time.timeScale=1;
		}
	}
}
