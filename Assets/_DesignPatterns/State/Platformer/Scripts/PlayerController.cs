using UnityEngine;

namespace DesignPatterns.State.Platformer
{
    public class PlayerController : MonoBehaviour
    {
        private IState currentState;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            currentState = new IdleState();
            currentState.OnEnter(transform, rb);
        }

        private void Update()
        {
            HandleInput();

            IState newState = currentState.UpdateState();
            if (newState != currentState)
                SwitchStates(newState);
        }

        private void HandleInput()
        {
            IState newState = currentState.HandleInput();
            if (newState != currentState)
                SwitchStates(newState);
        }

        private void SwitchStates(IState newState)
        {
            currentState.OnExit();
            currentState = newState;
            currentState.OnEnter(transform, rb);
        }
    }
}