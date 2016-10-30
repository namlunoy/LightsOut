using UnityEngine;
using System.Collections;

public class HVC_TestAds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickBanner()
	{
		HVC_AdsMng.ShowBanner ();
	}

	public void ClickBillboard()
	{
		HVC_AdsMng.LoadAndShowBillboard ();
	}
}
