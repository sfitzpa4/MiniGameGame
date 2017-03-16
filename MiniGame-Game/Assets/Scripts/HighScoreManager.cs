using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class HighScoreManager : MonoBehaviour {

    private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject scorePrefab;

    public Transform scoreParent;

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/testdb.db";
        GetScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GetScores()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetString(1) + " " + reader.GetInt32(2));
                     
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void ShowScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab);

            HighScore tmpScore = highScores[i];

            tmpObject.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());

            tmpObject.transform.SetParent(scoreParent);
        }
    }
}
