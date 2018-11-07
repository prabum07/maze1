using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playergyro : MonoBehaviour {

	public GameObject currentrgd;
	public Button gyrocheck;
	// Use this for initialization
	public float gyroy;
	public float gyroyoutput;
	public bool gyrobutton;
	public float finalout;
	public 		Vector3 lastpos;
	public float rotation;
	public Vector3 accelerometer;

	void Start () {
		gyrobutton = false;
		gyrocheck.onClick.AddListener(() => gyrocheckfunc());
		lastpos = currentrgd.transform.position;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
			accelerometer = Input.acceleration;
			//currentrgd.AddForce (Input.acceleration);
			gyroyoutput = Input.acceleration.y - gyroy;
			//		gyroyoutput = Mathf.Clamp (a,-0.5f,0.5f);
			if(gyroyoutput<0)
			{
				finalout = gyroyoutput*2;

			}
			if (gyroyoutput > 1) {
				finalout = 1f;

			} else if (gyroyoutput < -1) {

				finalout = -1f*2;
			} else 
			{
				finalout = gyroyoutput;
			}

			if(gyrobutton)
			{
				Vector3 temp=new Vector3(Input.acceleration.x,gyroyoutput,-2);

				float t=8*Time.deltaTime;
				//currentrgd.transform.position+=new Vector3(temp.x*t,temp.y*t,0);
				rotation = Input.GetAxis("Horizontal") * 5;
				//	currentrgd.GetComponent<Rigidbody2D> ().velocity=new Vector2 (temp.x*50 * Time.deltaTime, rotation * 60 * Time.deltaTime);

				//currentrgd.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (finalout * 60 * Time.deltaTime, finalout * 60 * Time.deltaTime), ForceMode2D.Force);
				currentrgd.GetComponent<Rigidbody2D> ().velocity=new Vector2 (temp.x*200 * Time.deltaTime, finalout * 300 * Time.deltaTime);
				lastpos = currentrgd.transform.position;
		

	


		}	

	}
	public void gyrocheckfunc()
	{
		print (PlayerPrefs.GetInt("prabu"));
		//	print (Input.acceleration);
		gyroy = Input.acceleration.y;
		gyrobutton = true;
	}
}
