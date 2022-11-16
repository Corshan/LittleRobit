using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "new diffiuclty settings", menuName = "ScriptableObjects/Difficulty Settings", order = 0)]
    public class DifficultySettings : ScriptableObject
    {
        public DifficultyEnum currentDifficulty;

        public Difficulty easy;
        public Difficulty medium;
        public Difficulty hard;
    }
}