using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class HighScoreManager : MonoBehaviour {

    private string connectionString;

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
}
