using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    #region FIELDS
    float probStandard;
    float probBonus;
    float probFreezer;
    float probSpeedup;
    [SerializeField]
    Vector2 startPosition;
    [SerializeField]
    GameObject[] blockPrefabs;
    int blocksPerRow = 11;
    int rows = 3;
    float horizontalOffset = 1.5f;
    #endregion

    #region METHODS
    private void Start()
    {
        SetProbabilities();
        BuildBlocks();
    }

    private void BuildBlocks()
    {
        Vector2 spawnPosition = new Vector2();
        spawnPosition = startPosition;

        for (int i = 0; i < rows;i++)
        {

            for (int b = 0; b < blocksPerRow; b++)
            {
                //Debug.Log(spawnPosition.ToString());
                Instantiate(SelectBlock(), spawnPosition, Quaternion.identity);
                spawnPosition.x += horizontalOffset;
            }
            spawnPosition += Vector2.up;
            spawnPosition.x = startPosition.x;
        }
    }

    private void SetProbabilities()
    {
        probStandard = ConfigurationUtils.ProbabilityStandard;
        probBonus = ConfigurationUtils.ProbabilityBonus;
        probFreezer = ConfigurationUtils.ProbabilityFreezer;
        probSpeedup = ConfigurationUtils.ProbabilitySpeedup;
        Debug.Log("All probabilities set.");
        Debug.Log("probStandard is " + probStandard);
    }

    GameObject SelectBlock()
    {
        
        float random = Random.Range(0f, 1f);
        Debug.Log("Random is: " + random);
        if(random <= probStandard)
        {
            //Standard Block
            return blockPrefabs[0];
        }
        else if (random > probStandard && random <= (probStandard+probBonus))
        {
            //Bonus Block
            return blockPrefabs[1];
        }
        else if(random > (probStandard + probBonus) && random <= (probStandard + probBonus + probFreezer))
        {
            //Freezer Block
            return blockPrefabs[2];
        }
        else
        {
            //Speedup
            return blockPrefabs[3];
        }
    }

    #endregion


}
