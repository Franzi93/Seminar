using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	public GameObject PauseMenu;
	private bool paused = false;

	// Use this for initialization
	void Start () {

		PauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
		if (PauseMenu != null) {PauseMenu.SetActive(false);}
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
		if(PauseMenu != null){PauseMenu.SetActive(paused);}

		SpielerBewegung go_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpielerBewegung>();
		Shoot go_shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();

		if (paused) {
			//Debug.Log("PAUSE!");
			Time.timeScale = 0;
			if (go_Player != null) {
				go_Player.status = false;
			}
			if (go_shoot != null) {
				go_shoot.status = false;
			}

		} else {
			//Debug.Log("GO!");
			Time.timeScale = 1;
			if (go_Player != null) {
				go_Player.status = true;
			}
			if (go_shoot != null) {
				go_shoot.status = true;
			}
		}

	}


	public void SpielBeenden()
	{
		Application.Quit();
	}

	public void LvlAuswahl()
	{
		Application.LoadLevel(0);
	}
}
