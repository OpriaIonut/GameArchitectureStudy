using UnityEngine;

namespace DesignPatterns.State.Platformer
{
    public interface IState
    {
        public void OnEnter(Transform transf, Rigidbody2D rb);
        public void OnExit();
        public IState HandleInput();
        public IState UpdateState();
    }
}