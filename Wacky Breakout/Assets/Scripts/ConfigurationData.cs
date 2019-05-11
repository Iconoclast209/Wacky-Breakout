using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data with default values
    static float ballLifetime = 5;
    static float ballSpawnTime = 3;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public float BallLifetime
    {
        get { return ballLifetime; }
    }
        
    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public float BallSpawnTime
    {
        get { return ballSpawnTime; }    
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader inputStream = null;
        
        try
        {
            inputStream = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string names = inputStream.ReadLine();
            string values = inputStream.ReadLine();
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if(inputStream != null)
            {
                inputStream.Close();
            }
        }

    }


    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        ballLifetime = float.Parse(values[0]);
        ballSpawnTime = float.Parse(values[1]);

    }

    #endregion
}
