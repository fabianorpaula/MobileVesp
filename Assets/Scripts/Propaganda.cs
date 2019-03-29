using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class Propaganda : MonoBehaviour
{
    string gameId = "1234567";
    bool testMode = true;

    void Start () {
        Monetization.Initialize (gameId, testMode);
    }

    public string placementId = "video";

    ///Propaganda Normal
    public void ShowAd () {
        StartCoroutine (ShowAdWhenReady ());
    }

    private IEnumerator ShowAdWhenReady () {
        while (!Monetization.IsReady (placementId)) {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;

        if(ad != null) {
            ad.Show ();
        }
    }

    public string placementIdR = "rewardedVideo";

    public void ShowAdR () {
        StartCoroutine (WaitForAd ());
    }

    IEnumerator WaitForAd () {
        while (!Monetization.IsReady (placementIdR)) {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementIdR) as ShowAdPlacementContent;

        if (ad != null) {
            ad.Show (AdFinished);
        }
    }

    void AdFinished (ShowResult result) {
        if (result == ShowResult.Finished) {
            // Reward the player
            Debug.Log("FICOU RICASSO");
        }
    }
    
}
