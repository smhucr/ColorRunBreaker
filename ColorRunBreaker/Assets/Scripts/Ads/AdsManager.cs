using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{

    private BannerView bannerView;
#if UNITY_ANDROID
    private string bannerID = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string bannerID = "ca-app-pub-3940256099942544/2934735716";
#else
  private string bannerID = "unused";
#endif
    //ca-app-pub-3940256099942544/6300978111 Google Test ID
    //ca-app-pub-7263574311319267/8664891566 SloXeN Games BannerID

    private InterstitialAd interstitialAd;
#if UNITY_ANDROID
    private string interstitialID = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
  private string interstitialID = "ca-app-pub-3940256099942544/4411468910";
#else
  private string interstitialID = "unused";
#endif

    //ca-app-pub-7263574311319267/5355383709 SloXeN Games InterstitialID
    //"ca-app-pub-3940256099942544/1033173712" Google Test ID

    private void Start()
    {
        // When true all events raised by GoogleMobileAds will be raised
        // on the Unity main thread. The default value is false.
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        LoadInterstitialAd();

    }

    public void RequestBanner()
    {
        this.bannerView = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    public void LoadInterstitialAd()
    {

        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        InterstitialAd.Load(interstitialID, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
            RegisterReloadHandler(interstitialAd);
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterReloadHandler(InterstitialAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
    {
        Debug.Log("Interstitial Ad full screen content closed.");

        // Reload the ad so that we can show another as soon as possible.
        LoadInterstitialAd();
    };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
    }
}
