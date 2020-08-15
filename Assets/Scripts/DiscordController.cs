using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{

    public Discord.Discord discord;

    // Use this for initialization
    void Start()
    {
        discord = new Discord.Discord(740483376288366603, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity

        {
            State = "Still Testing",
            Details = "Unity Is Epic."
        };
        var activityassets = new Discord.ActivityAssets
        {
            LargeImage = "logo"
        };
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
