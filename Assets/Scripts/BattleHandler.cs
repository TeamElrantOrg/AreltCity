using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleHandler : MonoBehaviour
{
         [SerializeField] private Transform pfCharacterBattle;
        private void start()
    {
        SpawnCharacter(true);
        SpawnCharacter(false);
    }
    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-50, 0);
        } else {
            position = new Vector3(+50, 0);
        }
        Instantiate(pfCharacterBattle, position, Quaternion.identity);
    }
}