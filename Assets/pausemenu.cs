using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour {

	public Button pausebtn;
	public Button playbtn;
	public Button homebtn;
	public bool homebtnbool;

	public GameObject pausemenuprnt;
	// Use this for initialization
	void Start () {
		homebtnbool = false;
		pausebtn.onClick.AddListener (() => pausebtnfunc ());
		playbtn.onClick.AddListener (() => playbtnfunc ());
		homebtn.onClick.AddListener (() => homebtnfunc ());


	}

	void pausebtnfunc()
	{
		mainuicanvas.maincan.gameObject.GetComponent<Image> ().enabled = true;
		pausemenuprnt.gameObject.SetActive (true);
		pausebtn.gameObject.SetActive (false);
		Time.timeScale = 0;
	}
	void playbtnfunc()
	{		Time.timeScale = 1;
		pausebtn.gameObject.SetActive (true);

		mainuicanvas.maincan.gameObject.GetComponent<Image> ().enabled = false;
		pausemenuprnt.gameObject.SetActive (false);
	}void homebtnfunc()
	{		Time.timeScale = 1;
		homebtnbool = true;
		pausebtn.gameObject.SetActive (false);

	//	mainuicanvas.maincan.gameObject.GetComponent<Image> ().enabled = true;
		pausemenuprnt.gameObject.SetActive (false);
		mainuicanvas.stagecollect.gameObject.SetActive (true);
		mainuicanvas.maincan.gameObject.GetComponent<Image> ().enabled = true;
		mainuicanvas.stagecollect.btnarrange ();
		mainuicanvas.maincan.playerpos.gyrobutton = false;
		mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
		mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
