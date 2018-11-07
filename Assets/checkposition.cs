using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkposition : MonoBehaviour {

	public GameObject notincorrectposition;
	public GameObject correctposition;
	public Button rewardadbtn;
	public Button startbtn;
	public Button backbtn;
	public bool backbtnbool;
	public bool rewardedbool;
	public GameObject timeimage;
	public GameObject enemyimage;
	public GameObject timesay;
	public Text timetext;


	// Use this for initialization
	void Start () {
		backbtnbool = false;
		rewardadbtn.onClick.AddListener (() => rewards ());
		startbtn.onClick.AddListener (() => startgame ());
		backbtn.onClick.AddListener (() => backbtnfunc ());


	}
	
	// Update is called once per frame
	void Update () {
		
	}public void backbtnfunc()
	{mainuicanvas.maincan.enemybug.speed = 1f;
		backbtnbool=true;
		mainuicanvas.maincan.click.Play ();

		rewardadbtn.gameObject.SetActive(true);
		mainuicanvas.stagecollect.gameObject.SetActive(true);
		rewardedbool = false;

	}
	public void rewards()
	{		mainuicanvas.maincan.click.Play ();
		
		rewardedbool = false;


		rewardadbtn.gameObject.SetActive (false);
	}
	public void startgame()
	{		mainuicanvas.maincan.click.Play ();
		
		rewardadbtn.gameObject.SetActive(true);

		mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive(true);
		for(int i=0;i<mainuicanvas.stagecollect.levels.Count;i++)
		{
			mainuicanvas.stagecollect.levels[i].gameObject.SetActive(false);
		}
		mainuicanvas.stagecollect.currentselectedlevel.gameObject.SetActive(true);
		mainuicanvas.maincan.mainblackbg.enabled=false;
		mainuicanvas.maincan.playerpos.gyrocheckfunc();
		//mainuicanvas.stagecollect.btnparent.gameObject.SetActive(false);
	//	mainuicanvas.stagecollect.gameObject.SetActive(true);
		if(mainuicanvas.stagecollect.typeenum==stagecollection.type.time)
		{

			if (rewardedbool) {
				mainuicanvas.maincan.totalsec = 30;
				mainuicanvas.maincan.mainsec = 30;
			} else {
				mainuicanvas.maincan.totalsec = 15;
				mainuicanvas.maincan.mainsec = 15;
			}
			
			StartCoroutine(	mainuicanvas.stagecollect.currentselectedlevel.levelstart());

		}
		if(mainuicanvas.stagecollect.typeenum==stagecollection.type.timeneemy)
		{
			
			if (rewardedbool) {
				mainuicanvas.maincan.totalsec = 30;
				mainuicanvas.maincan.mainsec = 30;
			} else {
				mainuicanvas.maincan.totalsec = 15;
				mainuicanvas.maincan.mainsec = 15;
			}
			mainuicanvas.maincan.enemybug.target1=mainuicanvas.stagecollect.currentselectedlevel.target1;
			mainuicanvas.maincan.enemybug.target2=mainuicanvas.stagecollect.currentselectedlevel.target2;
			StartCoroutine(	mainuicanvas.stagecollect.currentselectedlevel.enemytime());

		}
		if(mainuicanvas.stagecollect.typeenum==stagecollection.type.enemy)
		{
			mainuicanvas.maincan.enemybug.target1=mainuicanvas.stagecollect.currentselectedlevel.target1;
			mainuicanvas.maincan.enemybug.target2=mainuicanvas.stagecollect.currentselectedlevel.target2;

			StartCoroutine(	mainuicanvas.stagecollect.currentselectedlevel.enemylevel());

		}
		rewardedbool = false;
	}		

}
