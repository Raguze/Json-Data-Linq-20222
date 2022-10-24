using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO;
using System.IO;
using System.Linq;

public class GameController : MonoBehaviour
{
    public PlayersData playersData;

    private void Awake()
    {
        
    }

    //private void GenerateData()
    //{
    //    var players = new PlayersData();
    //    players.Players = new List<Player>()
    //    {
    //        new Player()
    //        {
    //            Name = "Zeh",
    //            Heroes = new List<Hero>()
    //            {
    //                new Hero()
    //                {
    //                    Name = "Zezinho",
    //                    Gold = 100,
    //                    Level = 40,
    //                    heroClass = HeroClass.Barbarian
    //                }
    //            }
    //        },
    //        new Player()
    //        {
    //            Name = "Luizinho",
    //            Heroes = new List<Hero>()
    //            {
    //                new Hero()
    //                {
    //                    Name = "Dolores",
    //                    Gold = 1000,
    //                    Level = 70,
    //                    heroClass = HeroClass.Wizard
    //                }
    //            }
    //        }
    //    };

    //    var json = JsonUtility.ToJson(players,true);
    //    GameEvents.OnHudText.Invoke(json);
    //}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            string v = (Random.value * 100).ToString();
            GameEvents.OnHudText.Invoke(v);
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            //GenerateData();
        }
        
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadJson();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Query1("China");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Query2("China");
        }
    }

    private void Query1(string country)
    {
        var result = playersData.players
            .Where(player => player.country == country)
            .Select(player => new { player.name,player.email})
            .ToList();
        
        ToHud(result.AllToString());
    }

    private void Query2(string country)
    {
        var result = playersData.players
            .Where(player => player.country == country)
            .OrderByDescending(player => player.points)
            .Select(player => new { player.name, player.points })
            .ToList();

        ToHud(result.AllToString());
    }

    private void ToHud(string value)
    {
        GameEvents.OnHudText.Invoke(value);
    }

    private void LoadJson()
    {
        var json = Resources.Load<TextAsset>("data/data");
        Debug.Log(json.text);
        playersData = JsonUtility.FromJson<PlayersData>(json.text);
        Debug.Log(playersData.players.Count);
    }
}
