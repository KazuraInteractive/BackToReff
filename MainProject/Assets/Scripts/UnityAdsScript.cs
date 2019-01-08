using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsScript : MonoBehaviour {

    public string bannerPlacement = "Banner";
    public bool testMode = false;

#if UNITY_IOS
    public const string gameID = "1234567";
#elif UNITY_ANDROID
    public const string gameID = "2995426";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif

    void Start()
    {
        Advertisement.Initialize(gameID, testMode);
    }
}
