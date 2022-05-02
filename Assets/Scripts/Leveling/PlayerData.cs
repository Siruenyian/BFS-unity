using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public float[] Scores=new float[10];


    public PlayerData(int levelat,float score)
    {
        switch (levelat)
        {
            case 0:
                this.Scores[0] = score;
                break;
            case 1:
                this.Scores[1] = score;
                break;
            case 2:
                this.Scores[2] = score;
                break;
            case 3:
                this.Scores[3] = score;
                break;
            default:
                break;
        }

    }
}
