using Unit;
using UnityEngine;

namespace AI
{
    public abstract class AiBotBase : MonoBehaviour
    {
        public abstract Animator Animator { get; }
        public abstract UnitMove Move { get; }  
        public abstract UnitMoveTargetUpdater TargetUpdater { get; }
        
    }
}