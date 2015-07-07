using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	public GameObject PauseMenu;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		PauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
		PauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			//Debug.Log("Escape!?");
			TogglePause();			
		}	
	}


	public void TogglePause()
	{
		paused = !paused;
		PauseMenu.SetActive(paused);
		SpielerBewegung go_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpielerBewegung>();
		Shoot go_shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
		if(paused)
		{
			//Debug.Log("PAUSE!");
			Time.timeScale=0;
			go_Player.status = false;
			go_shoot.status = false;

		}
		else
		{
			//Debug.Log("GO!");
			Time.timeScale=1;
			go_Player.status = true;
			go_shoot.status = true;
		}
	}
}
