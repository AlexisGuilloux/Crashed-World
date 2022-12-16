using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using Procedural_Generation;
using UnityEngine;

public class AudioAmbienceHandler : MonoBehaviour
{
    public FMODUnity.EventReference[] fmodEvents;


    private FMOD.Studio.EventInstance[] ambInstances;
    
    // Start is called before the first frame update
    void Start()
    {
        ambInstances = new EventInstance[fmodEvents.Length];

        for (int i = 0; i < ambInstances.Length; i++)
        {
            ambInstances[i] = FMODUnity.RuntimeManager.CreateInstance(fmodEvents[i]);
            ambInstances[i].start();
        }
        
        MapGeneratorEvents.waterLevelEvent += SubscribeWaterLevel;
        MapGeneratorEvents.treeDensityEvent += SubscribeTreeDensity;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < ambInstances.Length; i++)
        {
            ambInstances[i].stop(STOP_MODE.IMMEDIATE);
        }
        MapGeneratorEvents.waterLevelEvent -= SubscribeWaterLevel;
        MapGeneratorEvents.treeDensityEvent -= SubscribeTreeDensity;
    }

    private void SubscribeWaterLevel(float waterLevel)
    {
        for (int i = 0; i < ambInstances.Length; i++)
        {
            ambInstances[i].setParameterByName("WaterLevel", waterLevel);
        }
    }
    
    private void SubscribeTreeDensity(float treeDensity)
    {
        for (int i = 0; i < ambInstances.Length; i++)
        {
            ambInstances[i].setParameterByName("TreeDensity", treeDensity);
        }
    }
}
