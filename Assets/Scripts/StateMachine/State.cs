
namespace StateMachine
{
    public abstract class State
    {
        /// <summary>
        /// Called when this state is current state and Start happens
        /// </summary>
        /// <param name="stateMachine">Passed when state is entered by state machine (its own reference)
        /// can be stored in some variable so that it wont be passed to update and fixed update every time</param>
        public abstract void Start(StateMachine stateMachine);

        /// <summary>
        /// Called when this state is current state and Update happens
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Called when this state is current state and FixedUpdate happens
        /// </summary>
        public abstract void FixedUpdate();

        /// <summary>
        /// Called when state machine enters this state
        /// </summary>
        /// <param name="stateMachine">Passed when state is entered by state machine (its own reference)
        /// can be stored in some variable so that it wont be passed to update and fixed update every time</param>
        public abstract void StateEntered(StateMachine stateMachine);

        /// <summary>
        /// Called when state machine exits this state
        /// </summary>
        public abstract void StateExited();
        
    }
}
