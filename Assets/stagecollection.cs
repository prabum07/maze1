using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stagecollection : MonoBehaviour {

	public  playergyro gyro;
	public GameObject levelparent;
	public List<levelclass> levels=new List<levelclass>();
	public levelclass currentselectedlevel;
	public Color red ;
	public Color green;
	public Color yellow;
	public GameObject btnparent;
	public List<Button> btnlist = new List<Button> ();
	public enum type{none,time,enemy,timeneemy}
	public type typeenum;
	public Image time;
	public Image enemy;
	// Use this for initialization
	void Start () {
		for(int i=0;i<levelparent.transform.childCount;i++)
		{
			if (levelparent.transform.GetChild (i).transform.GetComponent<levelclass> ()) {
			
				levels.Add (levelparent.transform.GetChild (i).transform.GetComponent<levelclass> ());
			}
			
		}
		for (int i = 0; i < btnparent.transform.childCount; i++) {
			btnlist.Add (btnparent.transform.GetChild (i).transform.GetComponent<Button> ());

		}

		for(int i=0;i<btnlist.Count;i++)
		{
			
			btnlist [i].gameObject.SetActive (true);

			btnlist [i].GetComponent<buttonclass>().score.color=red;

			btnlist [i].GetComponent<buttonclass>().level.color=red;


			btnlist [i].onClick.RemoveAllListeners ();
			btnlist [i].gameObject.SetActive (false);
			
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void btnarrange()
	{
		mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
		mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (false);

		for(int i=0;i<btnlist.Count;i++)
		{

			btnlist [i].gameObject.SetActive (true);

			btnlist [i].GetComponent<buttonclass>().score.color=red;
			btnlist [i].GetComponent<buttonclass> ().activeenum = buttonclass.active.red;
			btnlist [i].GetComponent<buttonclass>().level.color=red;


			btnlist [i].onClick.RemoveAllListeners ();
			btnlist [i].gameObject.SetActive (false);

		}
		for(int i=0;i<levels.Count;i++)
		{
			btnlist [i].gameObject.SetActive (true);
			btnlist[i].GetComponent<buttonclass>().score.fillAmount=0;
			levels [i].currentactive = false;
			int k = i;
			btnlist[i].onClick.AddListener (() => mainuicanvas.maincan.playerposfunc (btnlist[k].GetComponent<buttonclass>().activeenum));

			btnlist[i].onClick.AddListener (() => mainuicanvas.maincan.currentlevel (levels[k]));
			btnlist [i].GetComponent<buttonclass> ().level.text = levels [i].level1.ToString();
			if(typeenum==type.time)
			{
				levels [i].prefsset1 ();
				time.gameObject.SetActive (true);
				enemy.gameObject.SetActive (false);

			}
			if(typeenum==type.enemy)
			{				mainuicanvas.maincan.enemybug.speed = 1f;
				
				levels [i].prefsset2 ();
				time.gameObject.SetActive (false);
				enemy.gameObject.SetActive (true);
			}
			if(typeenum==type.timeneemy)
			{
				mainuicanvas.maincan.enemybug.speed = 1f;
				time.gameObject.SetActive (true);
				enemy.gameObject.SetActive (true);
				levels [i].prefsset3 ();
			//	mainuicanvas.maincan.totalsec = 20;
			//	mainuicanvas.maincan.mainsec = 20;
			}

		}

		for(int i = 0; i < levels.Count; i++)
		{
			btnlist [i].GetComponent<buttonclass> ().score.fillAmount = levels [i].levelres;

		}

		for (int i = 0; i < levels.Count; i++) {
			if (levels [i].levelres == 0) {
			//	btnlist [i].GetComponent<buttonclass> ().score.fillAmount = levels [i].levelres;
				btnlist [i].GetComponent<buttonclass> ().score.color = yellow;

				btnlist [i].GetComponent<buttonclass> ().level.color = yellow;
				levels [i].currentactive = true;
				btnlist [i].GetComponent<buttonclass> ().activeenum = buttonclass.active.yellow;

				break;
			} else {
				//btnlist [i].GetComponent<buttonclass> ().score.fillAmount = levels [i].levelres;
				btnlist [i].GetComponent<buttonclass> ().score.color = green;
				btnlist [i].GetComponent<buttonclass> ().level.color = green;
				btnlist [i].GetComponent<buttonclass> ().activeenum = buttonclass.active.green;

			
			}
		}
	}
}
