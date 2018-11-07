using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainuicanvas : MonoBehaviour {
	public static mainuicanvas maincan;

	public AudioSource click;
	public static stagecollection stagecollect;
	public enemyclass enemybug;
	public admanager adscript;
	public playerclass player;
	public  checkposition checkpos;
	public scoreupdate score;
	public playergyro playerpos;
	public lockedstage lockedstage;
	public pausemenu pausemenu;
	public rewardmenu rewardmenu;
	public Button mainplaybtn;
	public GameObject screen1;
	public GameObject screen2;
	public Button time;
	public Button enemy;
	public Button timeenemy;
	public Button quit;

	public Image mainblackbg;
	public float totalsec;
	public float mainsec;
	public float remainingsec;
	public bool targethit;
	public Button levelselectback;
	public Button worldselectbtn;
	public Text adfunc;
	public Text adevent;
	// Use this for initialization
	void Start () {

		maincan = this.gameObject.GetComponent<mainuicanvas> ();
		stagecollect = GameObject.Find ("worlds").GetComponent<stagecollection>();
		stagecollect.gameObject.SetActive (false);
		screen1.gameObject.SetActive (true);
		screen2.gameObject.SetActive (false);
		print (stagecollect);

		mainplaybtn.onClick.AddListener (() => mainbtnfunc ());
		time.onClick.AddListener (() => timefunc ());

		enemy.onClick.AddListener (() => enemyfunc ());

		timeenemy.onClick.AddListener (() => timeenemyfunc ());
		levelselectback.onClick.AddListener (() => levelselectbackbtn ());
		worldselectbtn.onClick.AddListener (() => worldselectbackbtn ());
		quit.onClick.AddListener (() => quitfunc ());

		score.gameObject.SetActive (false);

	}


	void quitfunc()
	{
		Application.Quit ();
		maincan.click.Play ();

	}
	void levelselectbackbtn()
	{		maincan.click.Play ();
		
		screen1.gameObject.SetActive (true);
		screen2.gameObject.SetActive (false);

	}
	void worldselectbackbtn()
	{
		worldselectbtn.transform.parent.gameObject.SetActive (false);
		//screen1.gameObject.SetActive (true);
		screen2.gameObject.SetActive (true);

	}
	// Update is called once per frame
	void Update () {
		
	}
			public void mainbtnfunc()
	{		maincan.click.Play ();
		
		screen1.gameObject.SetActive (false);
		screen2.gameObject.SetActive (true);

			}

	public void timefunc()
	{		maincan.click.Play ();
		
		stagecollect.typeenum = stagecollection.type.time;screen2.gameObject.SetActive (false);
		stagecollect.gameObject.SetActive (true);
		stagecollect.btnarrange ();

	}
	public void enemyfunc()
	{		maincan.click.Play ();
		
		stagecollect.typeenum = stagecollection.type.enemy;		screen2.gameObject.SetActive (false);
		stagecollect.gameObject.SetActive (true);
		stagecollect.btnarrange ();


	}public void timeenemyfunc()
	{		maincan.click.Play ();
		
		stagecollect.typeenum = stagecollection.type.timeneemy;		screen2.gameObject.SetActive (false);
		stagecollect.gameObject.SetActive (true);
		stagecollect.btnarrange ();


	}

	public void playerposfunc(buttonclass.active temp)
	{		mainuicanvas.maincan.click.Play ();
		if (mainuicanvas.maincan.adscript.playable ()) {
			//mainuicanvas.maincan.adscript.rewardbasedvideo.Show ();
		//	mainuicanvas.maincan.adscript.playable ();

		} else {

		}
		mainuicanvas.maincan.enemybug.speed = 1f;
		if (temp != buttonclass.active.red) {
			StartCoroutine (playerpositioncheck ());

		} else {
			lockedstage.menu.transform.parent.gameObject.SetActive (true);

			lockedstage.menu.gameObject.SetActive (true);
			stagecollect.gameObject.SetActive (false);
			lockedstage.watchad.gameObject.SetActive (true);
			lockedstage.backbtn.gameObject.SetActive (true);
			lockedstage.play.gameObject.SetActive (false);



		}
	}
	public void currentlevel(levelclass current)
	{mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
		mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (false);
		stagecollect.currentselectedlevel = current;
			
	}

	public IEnumerator playerpositioncheck()
	{

		if (mainuicanvas.stagecollect.typeenum == stagecollection.type.time) {
			checkpos.enemyimage.SetActive (false);
			checkpos.timeimage.SetActive (true);
			checkpos.timesay.gameObject.SetActive (true);
			checkpos.timetext.text = 15.ToString ();

		}
		if (mainuicanvas.stagecollect.typeenum == stagecollection.type.timeneemy) {
			checkpos.enemyimage.SetActive (false);
			checkpos.timeimage.SetActive (true);
			checkpos.timesay.gameObject.SetActive (true);
			checkpos.timetext.text = 15.ToString ();


		}
		if (mainuicanvas.stagecollect.typeenum == stagecollection.type.enemy) {
			checkpos.enemyimage.SetActive (true);
			checkpos.timeimage.SetActive (false);
			checkpos.timesay.gameObject.SetActive (false);
			checkpos.timetext.text = 15.ToString ();

		}
		checkpos.gameObject.SetActive (true);
		stagecollect.gameObject.SetActive (false);
		while(stagecollect.gyro.gyrocheck)
		{
			


			if (playerpos.accelerometer.z < -0.5) {
				checkpos.correctposition.gameObject.SetActive (true);
				checkpos.notincorrectposition.gameObject.SetActive (false);


			} else if(playerpos.accelerometer.z > -0.5f){
				checkpos.notincorrectposition.gameObject.SetActive (true);
				checkpos.correctposition.gameObject.SetActive (false);

			}
			if(checkpos.backbtnbool)
			{
				checkpos.backbtnbool = false;
				break;
			}
			if(mainuicanvas.maincan.playerpos.gyrobutton)
			{
				break;
			}
			yield return null;
		}
		checkpos.correctposition.SetActive (false);
		checkpos.notincorrectposition.SetActive (false);

		yield return null;
	}
}
 