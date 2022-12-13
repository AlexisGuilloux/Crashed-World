using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticEventTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        var options = new InitializationOptions()
            .SetEnvironmentName("production");
 
        await UnityServices.InitializeAsync(options);
        
        Analytics.initializeOnStartup = true;
        Analytics.ResumeInitialization();
        List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        

        foreach (var id in consentIdentifiers)
        {
            Debug.Log($"consent: {id}");
        }
        
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "userID", UnityServices.ExternalUserId },
            { "eventName", "CustomEvent01" },
            { "eventUUID", DateTime.Now.GetHashCode().ToString() }
        };
        
        AnalyticsService.Instance.CustomData("CustomEvent01", parameters);

    }
}
