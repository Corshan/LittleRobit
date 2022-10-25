using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField]
    SceneIndexes LevelToChangeTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameEvents.current.levelChange((int) LevelToChangeTo);
        }
    }
}
