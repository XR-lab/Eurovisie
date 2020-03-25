using UnityEngine;

namespace Eurovision.Gameplay
{
    public class LookObject : MonoBehaviour
    {

        public virtual void SetAsActiveObject(){ }

        public virtual void SetAsInActiveObject() { }

        public virtual void SetAsGettingLookedAt() { }

        public virtual void SetAsNotGettingLookedAt() { }

    }
}
