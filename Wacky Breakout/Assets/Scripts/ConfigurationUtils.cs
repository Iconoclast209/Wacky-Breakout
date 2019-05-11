using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configData;

    #region Properties
    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public static float BallLifetime
    {
        get { return configData.BallLifetime; }
    }

    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float BallSpawnTime
    {
        get { return configData.BallSpawnTime; }    
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}