using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

class HighScore : IComparable<HighScore>
{
    public int Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    public HighScore(int id, int score, string name)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
    }

	public int CompareTo(HighScore other)
	{
		if (other.Score < this.Score) 
		{
			return -1;
		} 
		else if (other.Score > this.Score) 
		{
			return 1;
		} 
		else if (other.ID < this.ID) 
		{
			return -1;
		} 
		else if (other.ID > this.ID) 
		{
			return 1;
		}

		return 0;
	}
}
