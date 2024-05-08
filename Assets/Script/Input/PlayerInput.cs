//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Script/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""37eca179-abb2-4a46-a4bd-f287c7820219"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f126a075-e74d-46ea-83fa-3cacb4dbd6d5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HorizontalAndTunnel"",
                    ""type"": ""Value"",
                    ""id"": ""77987135-0588-482c-ae19-e492202a6c78"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TunnelKey"",
                    ""type"": ""PassThrough"",
                    ""id"": ""50c5522f-e60f-477f-911d-c83de15f2a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""642c0140-0c4a-4dda-a5d4-0ca75020053b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""504343bf-3275-4ba2-87f1-113c61ffbbff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAndTunnel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""49262784-6317-4208-9b97-d5696d34a3c2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAndTunnel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""34c19f8b-44f4-4d94-8a40-7705a9115646"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAndTunnel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""787a6c2f-aa46-46a8-9439-4f4270c86af2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAndTunnel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""12c197a5-9955-4240-ad3f-5b86b0f2c235"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAndTunnel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1b2ee464-3b33-4d47-922f-a74fe1cb9920"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TunnelKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Action"",
            ""id"": ""827827c2-e019-4acf-a7da-14afac889030"",
            ""actions"": [
                {
                    ""name"": ""TunnelKey"",
                    ""type"": ""Button"",
                    ""id"": ""15dce1b9-4a02-4450-a826-c54c93674c67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d4619a31-3996-46a8-80d8-caf82870bffc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TunnelKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_HorizontalAndTunnel = m_Movement.FindAction("HorizontalAndTunnel", throwIfNotFound: true);
        m_Movement_TunnelKey = m_Movement.FindAction("TunnelKey", throwIfNotFound: true);
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_TunnelKey = m_Action.FindAction("TunnelKey", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_HorizontalAndTunnel;
    private readonly InputAction m_Movement_TunnelKey;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @HorizontalAndTunnel => m_Wrapper.m_Movement_HorizontalAndTunnel;
        public InputAction @TunnelKey => m_Wrapper.m_Movement_TunnelKey;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @HorizontalAndTunnel.started += instance.OnHorizontalAndTunnel;
            @HorizontalAndTunnel.performed += instance.OnHorizontalAndTunnel;
            @HorizontalAndTunnel.canceled += instance.OnHorizontalAndTunnel;
            @TunnelKey.started += instance.OnTunnelKey;
            @TunnelKey.performed += instance.OnTunnelKey;
            @TunnelKey.canceled += instance.OnTunnelKey;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @HorizontalAndTunnel.started -= instance.OnHorizontalAndTunnel;
            @HorizontalAndTunnel.performed -= instance.OnHorizontalAndTunnel;
            @HorizontalAndTunnel.canceled -= instance.OnHorizontalAndTunnel;
            @TunnelKey.started -= instance.OnTunnelKey;
            @TunnelKey.performed -= instance.OnTunnelKey;
            @TunnelKey.canceled -= instance.OnTunnelKey;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Action
    private readonly InputActionMap m_Action;
    private List<IActionActions> m_ActionActionsCallbackInterfaces = new List<IActionActions>();
    private readonly InputAction m_Action_TunnelKey;
    public struct ActionActions
    {
        private @PlayerInput m_Wrapper;
        public ActionActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TunnelKey => m_Wrapper.m_Action_TunnelKey;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void AddCallbacks(IActionActions instance)
        {
            if (instance == null || m_Wrapper.m_ActionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ActionActionsCallbackInterfaces.Add(instance);
            @TunnelKey.started += instance.OnTunnelKey;
            @TunnelKey.performed += instance.OnTunnelKey;
            @TunnelKey.canceled += instance.OnTunnelKey;
        }

        private void UnregisterCallbacks(IActionActions instance)
        {
            @TunnelKey.started -= instance.OnTunnelKey;
            @TunnelKey.performed -= instance.OnTunnelKey;
            @TunnelKey.canceled -= instance.OnTunnelKey;
        }

        public void RemoveCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IActionActions instance)
        {
            foreach (var item in m_Wrapper.m_ActionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ActionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IMovementActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnHorizontalAndTunnel(InputAction.CallbackContext context);
        void OnTunnelKey(InputAction.CallbackContext context);
    }
    public interface IActionActions
    {
        void OnTunnelKey(InputAction.CallbackContext context);
    }
}
