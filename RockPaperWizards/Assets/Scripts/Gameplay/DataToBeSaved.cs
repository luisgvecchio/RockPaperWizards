
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class PlayerInfo
{
    public string name;
    public List<string> activeGames;
}
[System.Serializable]
public class GameInfo
{
    public string gameName;
    public string gameId;
    public int openPlayerSlots = 2;
    public int turnState;
    public List<PlayerInGameData> players;
}
[System.Serializable]

public class PlayerInGameData
{
    Animator anim;

    public string userId;
    public string name;

    public int voice;
    public int wizard;

    public int playerNumber;
    public int lives;
    public Attacks currentAttack;
}



