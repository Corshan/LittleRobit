using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "new difficulty", menuName = "ScriptableObjects/Difficulty", order = 0)]
    public class Difficulty : ScriptableObject
    {
        public int enemies;
        public int healthPacks;
        public int scrap;
        public int chargingStations;
    }
}