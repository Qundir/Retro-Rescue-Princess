using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RevivePanel : MonoBehaviour
{
    private string _adUnitId = "ca-app-pub-1428627333476346/3120455849";
    private RewardedAd _rewardedAd;
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        LoadRewardedAd();
        GameManager.Instance.AdsRemoved = true;
    }
    public void RestartGame()
    {
        GameManager.Instance.LoadLevel(1,0);
        GameManager.Instance.NewGame();
        GameManager.Instance.ScoreShouldPostLeaderboard();
    }
    public void AddLifeAdd()
    {
        GameManager.Instance.AddLife();
        GameManager.Instance.AddlifeAddLevelLoader();
        GameManager.Instance.FindRevivePanel();
    }
    public void LoadRewardedAd()
    {
      // Clean up the old ad before loading a new one.
      if (_rewardedAd != null)
      {
            _rewardedAd.Destroy();
            _rewardedAd = null;
      }
      var adRequest = new AdRequest();

      RewardedAd.Load(_adUnitId, adRequest,
          (RewardedAd ad, LoadAdError error) =>
          {

              if (error != null || ad == null)
              {
                  return;
              }
              _rewardedAd = ad;
          });
    }
    public void ShowRewardedAd()
    {
        if (GameManager.Instance.AdsRemoved == true)
        {
            // Reklamlar kaldırıldıysa doğrudan ekstra can ekleyin
            AddLifeAdd();
            return;
        }

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                AddLifeAdd();
            });
        }
    }


    private void RegisterEventHandlers(RewardedAd ad)
    {
    // Raised when the ad is estimated to have earned money.
    ad.OnAdPaid += (AdValue adValue) =>
    {
        Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
            adValue.Value,
            adValue.CurrencyCode));
    };
    // Raised when an impression is recorded for an ad.
    ad.OnAdImpressionRecorded += () =>
    {
        Debug.Log("Rewarded ad recorded an impression.");
    };
    // Raised when a click is recorded for an ad.
    ad.OnAdClicked += () =>
    {
        Debug.Log("Rewarded ad was clicked.");
    };
    // Raised when an ad opened full screen content.
    ad.OnAdFullScreenContentOpened += () =>
    {
        Debug.Log("Rewarded ad full screen content opened.");
    };
    // Raised when the ad closed full screen content.
    ad.OnAdFullScreenContentClosed += () =>
    {
        Debug.Log("Rewarded ad full screen content closed.");
    };
    // Raised when the ad failed to open full screen content.
    ad.OnAdFullScreenContentFailed += (AdError error) =>
    {
        Debug.LogError("Rewarded ad failed to open full screen content " +
                       "with error : " + error);
    };
}
    private void RegisterReloadHandler(RewardedAd ad)
    {
    // Raised when the ad closed full screen content.
    ad.OnAdFullScreenContentClosed += () =>
    {
        Debug.Log("Rewarded Ad full screen content closed.");

        // Reload the ad so that we can show another as soon as possible.
        LoadRewardedAd();
    };
    // Raised when the ad failed to open full screen content.
    ad.OnAdFullScreenContentFailed += (AdError error) =>
    {
        Debug.LogError("Rewarded ad failed to open full screen content " +
                       "with error : " + error);

        // Reload the ad so that we can show another as soon as possible.
        LoadRewardedAd();
    };
}   
}
