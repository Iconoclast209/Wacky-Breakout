using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public static class ScoreKeeper
{
    #region FIELDS
    static int currentScore;
    static int highScore;
    const string scoreFileName = "scores.csv";
    #endregion

    #region PROPERTIES
    public static int CurrentScore
    {
        get { return currentScore; }
    }

    public static int HighScore
    {
        get { return highScore; }
    }
    #endregion

    #region METHODS
    public static void ReadScoresFromFile()
    {
        StreamReader inputStream = null;

        try
        {
            inputStream = File.OpenText(Path.Combine(Application.streamingAssetsPath, scoreFileName));
            string names = inputStream.ReadLine();
            string values = inputStream.ReadLine();
            //SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (inputStream != null)
            {
                inputStream.Close();
            }
        }
    }


    public static void WriteScoreToFile(int score)
    {
        //Check to see if new high score

        //Write scores to file
        try
        {
            StreamWriter writer = new StreamWriter(Path.Combine(Application.streamingAssetsPath, scoreFileName));
            {
                writer.WriteLine("currentScore, highScore");

                if (score > highScore)
                {
                    writer.WriteLine(score + "," + score);
                }
                else
                {
                    writer.WriteLine(score + "," + highScore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }
    #endregion
}
