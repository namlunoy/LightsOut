using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;

/// <summary>
/// Design to easy to use Ads in your game
/// </summary>

public class HVC_AdsMng : MonoBehaviour {
	
	#if UNITY_EDITOR
	const string banerId = "ca-app-pub-6921176146936171/4010581843";
	const string billboardId = "ca-app-pub-6921176146936171/2533848643";
	#elif UNITY_ANDROID
	const string banerId = "ca-app-pub-6921176146936171/4010581843";
	const string billboardId = "ca-app-pub-6921176146936171/2533848643";
	#elif UNITY_IPHONE
	const string banerId = "ca-app-pub-6921176146936171/6225247848";
	const string billboardId = "ca-app-pub-6921176146936171/7701981041";
	#else
	const string banerId = "ca-app-pub-6921176146936171/4010581843";
	const string billboardId = "ca-app-pub-6921176146936171/2533848643";
	#endif

	private static InterstitialAd interstitial;

	public static void ShowBanner(AdPosition adPos = AdPosition.Top)
	{
		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(banerId, AdSize.Banner, adPos);
		bannerView.OnAdClosed += OnAdClosed;
		bannerView.OnAdFailedToLoad += OnAdFailedToLoad;
		bannerView.OnAdLeavingApplication += OnAdLeavingApplication;
		bannerView.OnAdLoaded += OnAdLoaded;
		bannerView.OnAdOpening += OnAdOpening;	

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	public static void LoadBillboard()
	{
		interstitial = new InterstitialAd(billboardId);
		AdRequest request = new AdRequest.Builder().Build();
		interstitial.LoadAd(request);
	}

	public static void ShowBillboard()
	{
		if(interstitial.IsLoaded())
		interstitial.Show ();
	}

	public static void LoadAndShowBillboard()
	{
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(billboardId);
		interstitial.OnAdClosed += OnAdClosed;
		interstitial.OnAdFailedToLoad += OnAdFailedToLoad;
		interstitial.OnAdLeavingApplication += OnAdLeavingApplication;
		interstitial.OnAdLoaded += Billboard_OnAdLoaded;
		interstitial.OnAdOpening += OnAdOpening;

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		
	}

	private static void OnAdClosed(object sender, System.EventArgs e)
	{
		Debug.Log ("OnAdClosed");
	}

	private static void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
	{
		Debug.Log ("OnAdFailedToLoad");
	}

	private static void OnAdLeavingApplication(object sender, System.EventArgs e)
	{
		Debug.Log ("OnAdLeavingApplication");
	}

	private static void OnAdLoaded(object sender, System.EventArgs e)
	{
		Debug.Log ("OnAdLoaded");
	}

	private static void Billboard_OnAdLoaded(object sender, System.EventArgs e)
	{
		if(interstitial.IsLoaded())
			interstitial.Show ();
		Debug.Log ("OnAdLoaded");
	}

	private static void OnAdOpening(object sender, System.EventArgs e)
	{
		Debug.Log ("OnAdOpening");
	}
}
