using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class DatabaseHandler : MonoBehaviour
{
    public static bool statsLoaded = false;
    private string connectionString;

    void Start()
    {
        if (!DatabaseHandler.statsLoaded)
        {
            initStats();
            initTrackers();
            statsLoaded = true;
        }
    }

    private void initStats() //Gameplay affecting stats dmg etc...
    {
        PermanentUpgrade[] upgrades = LoadStatsArray();
        if (upgrades == null)
        {
            if (SaveStatsArray(PermanentStats.upgrades))
            {
                upgrades = LoadStatsArray();
            }
        }

        PermanentStats.upgrades = upgrades;
    }

    private void initTrackers()//Currency + kills
    {
        int[] stats = LoadStatTrackers();
        if (stats == null)
        {
            int[] initStats = { PermanentStats.currency, PermanentStats.killCount };
            if (SaveStatTrackers(initStats))
            {
                stats = LoadStatTrackers();

            }

        }
        PermanentStats.currency = stats[0];
        PermanentStats.killCount = stats[1];
    }

    public static bool SaveStatTrackers(int[] array)
    {
        try
        {
            using (FileStream fileStream = File.Create("statTracker.dat"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, array);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error saving currency and kills: " + e.Message);
            return false;
        }

        return true;
    }

    private int[] LoadStatTrackers()
    {
        try
        {
            using (FileStream fileStream = File.Open("statTracker.dat", FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (int[])binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error loading currency and kills: " + e.Message);
            return null;
        }
    }

    public static bool SaveStatsArray(PermanentUpgrade[] array)
    {
        try
        {
            using (FileStream fileStream = File.Create("statsArray.dat"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, array);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error saving player array: " + e.Message);
            return false;
        }

        return true;
    }

    private PermanentUpgrade[] LoadStatsArray()
    {
        try
        {
            using (FileStream fileStream = File.Open("statsArray.dat", FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (PermanentUpgrade[])binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error loading stats array: " + e.Message);
            return null;
        }
    }

}
