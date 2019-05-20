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
    static float ballLifetime = 1;
    static float minBallSpawnTime = 1;
    static float maxBallSpawnTime = 1;
    static int numberBallsPerGame = 1;
    static float probabilityStandard = 1;
    static float probabilityBonus = 1;
    static float probabilityFreezer = 1;
    static float probabilitySpeedup = 1;
    static int pointsStandard = 1;
    static int pointsFreezer = 1;
    static int pointsSpeedup = 1;
    #endregion

    #region Properties
        
    public float BallLifetime
    {
        get { return ballLifetime; }
    }
    
    public float MinBallSpawnTime
    {
        get { return minBallSpawnTime; }    
    }

    public float MaxBallSpawnTime
    {
        get { return maxBallSpawnTime; }
    }

    public int NumberBallsPerGame
    {
        get { return numberBallsPerGame; }
    }

    public float ProbabilityStandard
    {
        get { return probabilityStandard; }
    }

    public float ProbabilityBonus
    {
        get { return probabilityBonus; }
    }

    public float ProbabilityFreezer
    {
        get { return probabilityFreezer; }
    }

    public float ProbabilitySpeedup
    {
        get { return probabilitySpeedup; }
    }
    
    public int PointsStandard
    {
        get { return pointsStandard; }
    }

    public int PointsFreezer
    {
        get { return pointsFreezer; }
    }

    public int PointsSpeedup
    {
        get { return pointsSpeedup; }
    }

    #endregion

    #region Constructor

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
    #endregion

    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        ballLifetime = float.Parse(values[0]);
        minBallSpawnTime = float.Parse(values[1]);
        maxBallSpawnTime = float.Parse(values[2]);
        numberBallsPerGame = int.Parse(values[3]);
        probabilityStandard = float.Parse(values[4]);
        probabilityBonus = float.Parse(values[5]);
        probabilityFreezer = float.Parse(values[6]);
        probabilitySpeedup = float.Parse(values[7]);
        pointsStandard = int.Parse(values[8]);
        pointsFreezer = int.Parse(values[9]);
        pointsSpeedup = int.Parse(values[10]);

    }
}
