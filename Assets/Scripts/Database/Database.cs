using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Database
{
    private const string DbName = "Database.s3db";
    private const string TABLE_RANKING = "RankingRecords";

    private string _connPath;
    private IDbConnection _dbConn;

    public Database()
    {
        _connPath = $"URI=file:{Application.dataPath}/SQLiteDB/{DbName}";
        _dbConn = new SqliteConnection(_connPath);

        // Check if the table exists before attempting to drop it
        if (!CheckTableExistence(TABLE_RANKING))
        {
            CreateTable_Ranking();
        }
        else
        {
            Debug.Log("Table already exists");
        }
    }

    #region COMMON_METHODS
    private void PostQueryToDB(string query)
    {
        try
        {
            _dbConn.Open();

            IDbCommand command = _dbConn.CreateCommand();
            command.CommandText = query;
            command.ExecuteReader();

            command.Dispose();
            command = null;
        }catch(System.Exception e)
        {
            Debug.LogError($"*** Post query ERROR ***\n{e.Message}");
        }
        finally
        {
            _dbConn.Close();
        }
    }
    #endregion

    #region TABLE_RANKING_ACTIONS
    private void DropTable_Ranking()
    {
        try
        {
            string query = $"DROP TABLE IF EXISTS {TABLE_RANKING}";
            PostQueryToDB(query);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"*** Drop table ranking ERROR ***\n{e.Message}");
        }

    }

    private void CreateTable_Ranking()
    {
        string query = $"CREATE TABLE IF NOT EXISTS {TABLE_RANKING} " +
                        $"(Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        $"Name VARCHAR(50) NOT NULL," +
                        $"Score INTEGER NOT NULL)";
        PostQueryToDB(query);
    }

    public void AddRankingRecord(RankingModel model)
    {
        string query = $"INSERT INTO {TABLE_RANKING} (Name, Score) VALUES('{model.Name}', {model.Score})";
        PostQueryToDB(query);
    }

    private bool CheckTableExistence(string table)
    {
        bool tableExists = false;
        try
        {
            _dbConn.Open();

            IDbCommand command = _dbConn.CreateCommand();
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{table}';";
            command.CommandText = query;
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                tableExists = true;
            }

            command.Dispose();
            command = null;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"*** Post query ERROR ***\n{e.Message}");
        }
        finally
        {
            _dbConn.Close();
        }

        return tableExists;
    }

    public List<RankingModel> GetRankingRecords()
    {
        List<RankingModel> records = new List<RankingModel>();
        try
        {
            _dbConn.Open();

            IDbCommand command = _dbConn.CreateCommand();
            string query = $"SELECT Id, Name, Score FROM {TABLE_RANKING} ORDER BY Score DESC";
            command.CommandText = query;
            IDataReader reader =  command.ExecuteReader();

            while (reader.Read())
            {
                RankingModel model = new RankingModel(reader.GetString(1), reader.GetInt32(2));
                records.Add(model);
            }

            command.Dispose();
            command = null;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"*** Post query ERROR ***\n{e.Message}");
        }
        finally
        {
            _dbConn.Close();
        }

        return records;
    }
    #endregion
}
