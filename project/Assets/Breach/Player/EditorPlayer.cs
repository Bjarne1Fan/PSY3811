using System.Collections;
using System.Collections.Generic;
using Breach.WildWaters.Apps;
using UnityEngine;
using UnityEngine.InputSystem;
using static Breach.WildWaters.Player.PlayerActions;

namespace Breach.WildWaters.Player
{
    /// <summary>
    /// Editor player with WASD movement
    /// Responsible for everything that has to do with how the EditorPlayer interacts with the world
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class EditorPlayer : BasePlayerController, ISimulationControlsActions
    {
        [SerializeField] private float horizontalMultiplier = 1500f;
        [SerializeField] private float speedBoost = 3f;
        [SerializeField] private float rotMultiplier = 800f;
        private new Rigidbody rigidbody;
        protected IPlaybackControls controller;
        public void SetSimulationController(IPlaybackControls controller) => this.controller = controller;

        protected override void Awake()
        {
            base.Awake();
            rigidbody = GetComponent<Rigidbody>();
        }

        protected override void Start()
        {
            base.Start();

            if (controller != null) playerActions.SimulationControls.SetCallbacks(this); // If gamemode is observer, controller will be null
        }
        public void OnPlaySimulation(InputAction.CallbackContext context)
        {
            if (context.started) controller.Play();
        }

        public void OnPauseSimulation(InputAction.CallbackContext context)
        {
            if (context.started) controller.Pause();
        }

        public void OnStopSimulation(InputAction.CallbackContext context)
        {
            if (context.started) controller.Stop();
        }

        private void FixedUpdate()
        {
            var forward = playerActions.EditorMovement.MoveForward.ReadValue<float>();
            var right = playerActions.EditorMovement.MoveRight.ReadValue<float>();
            var up = playerActions.EditorMovement.MoveUp.ReadValue<float>();
            var boost = playerActions.EditorMovement.SpeedBoost.ReadValue<float>();

            rigidbody.AddForce(
                (transform.forward * forward + transform.right * right + transform.up * up) 
                * Time.deltaTime 
                * horizontalMultiplier 
                * Mathf.Lerp(1, speedBoost, boost), 
                ForceMode.Force
            );


            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, right*10, 0));

            // TODO: Fix mouse-look rotation in editor

            // var rotation = playerActions.EditorMovement.Rotation.ReadValue<Vector2>();
            // Log.I($"Rotation: {rotation}");
            // rigidbody.AddTorque(Vector3.up * rotation.x * rotMultiplier, ForceMode.Force);
            // var projectedPosition = playerCamera.ScreenToWorldPoint(rotation);
            // Log.I($"WorldPos: {projectedPosition}");

            // this.transform.rotation = Quaternion.LookRotation((projectedPosition - this.transform.position).normalized, Vector3.up);
        }
    }
}
