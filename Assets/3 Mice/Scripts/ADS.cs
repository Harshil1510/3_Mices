using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class ADS : MonoBehaviour
{/*
    InterstitialAd InterstitialAdRef;*/
    BannerView BannerViewRef;
   /* RewardedAd RewardedAdRef;*/

    public string BannerAdID/*, InterstitialAdID, RewardAdID*/;

    bool? IsInitialized;

    private void Awake()
    {
        InitializAdMob();
    }

    void InitializAdMob()
    {
        if (IsInitialized != null) return;

        MobileAds.Initialize(initiStatus =>
        {
            IsInitialized = true;
            LoadBannerAd();/*
            LoadInterstitialAd();
            LoadRewardAd();*/
        });
    }

    void LoadBannerAd()
    {
        if (BannerViewRef != null)
        {
            DestroyBannerView();
        }


        string adId;
        if (Application.platform == RuntimePlatform.Android)
        {
            adId = BannerAdID;
        }
        else
        {
            adId = BannerAdID;
        }
        BannerViewRef = new BannerView(adId, AdSize.IABBanner, AdPosition.Bottom);

        AdRequest adRequest = new AdRequest();

        BannerViewRef.LoadAd(adRequest);

        BannerViewRef.Show();
    }

    void DestroyBannerView()
    {
        BannerViewRef.Hide();
        BannerViewRef.Destroy();
        BannerViewRef = null;
    }

    /*void LoadInterstitialAd()
    {
        if (InterstitialAdRef != null) { DestroyInterstitialAd(); }

        AdRequest adRequest = new AdRequest();

        InterstitialAd.Load(InterstitialAdID, adRequest, (ad, error) =>
        {
            if (error != null) { Debug.LogError(error); return; }

            InterstitialAdRef = ad;
        });
    }
*/
 /*   public void ShowInterstitialAd()
    {
        if (InterstitialAdRef != null && InterstitialAdRef.CanShowAd())
        {
            InterstitialAdRef.Show();
        }
        else
        {
            Debug.Log("IntertitialAd can not be shown");
            LoadInterstitialAd();
        }
    }

    void DestroyInterstitialAd()
    {
        InterstitialAdRef?.Destroy();
    }

    void LoadRewardAd()
    {
        if (RewardedAdRef != null)
        {
            DestroyRewardAd();
        }

        AdRequest AdRequest = new AdRequest();

        RewardedAd.Load(RewardAdID, AdRequest, (ad, error) =>
        {
            if (error == null)
            {
                RewardedAdRef = ad;
            }
            else { Debug.Log(error); RewardedAdRef = null; }
        });
    }

    public void ShowRewardAd()
    {
        if (RewardedAdRef != null && RewardedAdRef.CanShowAd())
        {
            RewardedAdRef.Show(reward =>
            {
                Debug.Log("Reward granted Successfully");
            });
        }
    }*/
/*
    void DestroyRewardAd()
    {
        RewardedAdRef?.Destroy();
    }*/
}