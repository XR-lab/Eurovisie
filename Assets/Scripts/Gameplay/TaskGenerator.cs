using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Gameplay
{
    public class TaskGenerator : MonoBehaviour
    {
        [SerializeField] private LookObject[] _targets;
        [SerializeField] private float minDuration;
        [SerializeField] private float maxDuration;

        public Task GenerateTask()
        {
            int randomIndex = Random.Range(0, _targets.Length);
            float randomDuration = Random.Range(minDuration, maxDuration);

            return new Task(_targets[randomIndex], randomDuration);
        }
    }
}