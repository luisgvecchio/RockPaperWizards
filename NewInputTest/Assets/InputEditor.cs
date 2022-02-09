//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/InputEditor.inputactions
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

public partial class @InputEditor : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputEditor()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputEditor"",
    ""maps"": [
        {
            ""name"": ""Base"",
            ""id"": ""9d54b879-b766-43fd-8498-a11f03f29c36"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""b181c3eb-6b75-4ee4-837f-48378e541adc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f42d2276-f370-4fe0-9bc7-916dd913cbd6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Jump = m_Base.FindAction("Jump", throwIfNotFound: true);
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

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_Jump;
    public struct BaseActions
    {
        private @InputEditor m_Wrapper;
        public BaseActions(@InputEditor wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Base_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);
    public interface IBaseActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
}
