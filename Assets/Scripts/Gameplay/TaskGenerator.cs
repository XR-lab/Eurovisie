using UnityEngine;

namespace Eurovision.Gameplay
{
    public class TaskGenerator : MonoBehaviour
    {
        [SerializeField] private LookObject[] _targets;
        [SerializeField] private float _minDuration;
        [SerializeField] private float _maxDuration;

        public Task GenerateTask()
        {
            int randomIndex = Random.Range(0, _targets.Length);
            float randomDuration = Random.Range(_minDuration, _maxDuration);

            return new Task(_targets[randomIndex], randomDuration);
        }
    }
}