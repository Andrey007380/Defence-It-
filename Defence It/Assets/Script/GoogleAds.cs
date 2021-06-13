using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Common;
using GoogleMobileAds.Api;
using System;

public class GoogleAds : MonoBehaviour
{
    private RewardedAd rewardedAd;


    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        
    }


    public void CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7116017589805984/8193818972";
#else
            string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;
        this.rewardedAd.OnUserEarnedReward += RewardedAd_OnUserEarnedReward;
        this.rewardedAd.OnAdClosed += RewardedAd_OnAdClosed;
        

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    private void RewardedAd_OnAdClosed(object sender, EventArgs e)
    {
        GameStatsMechanics.Instance.Restart();   
    }

    private void RewardedAd_OnUserEarnedReward(object sender, Reward e)
    {
        GameStatsMechanics.Instance.Restart();
        Drop.bullets -= (int)(Drop.bullets * 0.25);
    }

    private void RewardedAd_OnAdLoaded(object sender, EventArgs e)
    {
        GameStatsMechanics.Instance.Restart();
        rewardedAd.Show();
    }
    
}
