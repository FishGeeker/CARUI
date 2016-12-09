using System;
using UnityEngine;
using System.Collections;
#if CW_Admob
using GoogleMobileAds.Api;
#endif

/*
 * Download the package here - https://github.com/googleads/googleads-mobile-unity/releases
 * Get the Ad Units from here - https://www.google.com/admob/
*/

public class AdManager : MonoBehaviour 
{
	#if CW_Admob
	#if UNITY_ANDROID
	public string BannerAdUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
	#elif UNITY_IPHONE
	public string BannerAdUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
	#else
	public const string BannerAdUnitId = "unexpected_platform";
	#endif

	#if UNITY_ANDROID
	public string InterstitialAdUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
	#elif UNITY_IPHONE
	public string InterstitialAdUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
	#else
	public const string InterstitialAdUnitId = "unexpected_platform";
	#endif

	[Tooltip("After how many 'gameovers' should we show an interstitial ad?")]
	public int AdCounter;

	private int c;

	internal BannerView bannerView;
	internal InterstitialAd interstitial;

	private void Awake()
	{
		RequestBanner();
		RequestInterstitial();
	}

	private void Start()
	{
		c=AdCounter;
	}

	private void RequestBanner()
	{
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(BannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnBannerAdFailedToLoad;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnBannerAdClosed;
		// Called when the ad click caused the user to leave the application.
		bannerView.OnAdLeavingApplication += HandleOnBannerAdLeavingApplication;

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	internal void RequestInterstitial()
	{
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(InterstitialAdUnitId);

		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when the user returned from the app after an ad click.
		interstitial.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	internal void ShowInterstitial()
	{
		if(AdCounter<=0)
		{
			if (interstitial.IsLoaded()) 
			{
				interstitial.Show();
				RequestInterstitial();

				//Reset the ad counter
				AdCounter=c;
			}
		}
		else if(AdCounter>0)
			AdCounter -=1;
	}

	void OnDisable()
	{
		DestroyBanner();
		DestroyInterstitial();
	}

	void DestroyInterstitial()
	{
		// Destroy the listeners
		interstitial.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
		interstitial.OnAdClosed -= HandleOnAdClosed;
		interstitial.OnAdLeavingApplication -= HandleOnAdLeavingApplication;

		interstitial.Destroy();
	}

	void DestroyBanner()
	{
		// Destroy the listeners
		bannerView.OnAdFailedToLoad -= HandleOnBannerAdFailedToLoad;
		bannerView.OnAdClosed -= HandleOnBannerAdClosed;
		bannerView.OnAdLeavingApplication -= HandleOnBannerAdLeavingApplication;

		bannerView.Destroy();
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		#if DEBUG
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		#endif
		DestroyInterstitial();
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		#if DEBUG
		print("HandleInterstitialClosed event received");
		#endif
		DestroyInterstitial();
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		#if DEBUG
		print("HandleInterstitialLeftApplication event received");
		#endif
		DestroyInterstitial();
	}

	public void HandleOnBannerAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		#if DEBUG
		print("HandleBannerFailedToLoad event received with message: " + args.Message);
		#endif
		DestroyBanner();
	}

	public void HandleOnBannerAdClosed(object sender, EventArgs args)
	{
		#if DEBUG
		print("HandleBannerClosed event received");
		#endif
		DestroyBanner();
	}

	public void HandleOnBannerAdLeavingApplication(object sender, EventArgs args)
	{
		#if DEBUG
		print("HandleBannerLeftApplication event received");
		#endif
		DestroyBanner();
	}
	#endif
}