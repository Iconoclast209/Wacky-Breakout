using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configData;

    #region PROPERTIES
    
    public static float BallLifetime
    {
        get { return configData.BallLifetime; }
        //used in Ball.cs
    }
        
    public static float MinBallSpawnTime
    {
        get { return configData.MinBallSpawnTime; }
        //used in BallSpawner.cs
    }
    public static float MaxBallSpawnTime
    {
        get { return configData.MaxBallSpawnTime; }
        //used in BallSpawner.cs
    }

    public static int NumberBallsPerGame
    {
        get { return configData.NumberBallsPerGame; }
        //used in GameController.cs
    }

    public static float ProbabilityStandard
    {
        get { return configData.ProbabilityStandard; }
    }

    public static float ProbabilityBonus
    {
        get { return configData.ProbabilityBonus; }
    }

    public static float ProbabilityFreezer
    {
        get { return configData.ProbabilityFreezer; }

    }

    public static float ProbabilitySpeedup
    {
        get { return configData.ProbabilitySpeedup; }
    }

    public static int PointsStandard
    {
        get { return configData.PointsStandard; }
        //used in Block.cs
    }

    public static int PointsFreezer
    {
        get { return configData.PointsFreezer; }
        //used in Block.cs
    }

    public static int PointsSpeedup
    {
        get { return configData.PointsSpeedup; }
        //used in Block.cs
    }

    #endregion

    #region METHODS
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
    #endregion
}