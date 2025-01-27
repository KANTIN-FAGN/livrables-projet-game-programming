//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Game/Scripts/Weapons/RifleFire/IA_RifleFire.inputactions
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

public partial class @IA_RifleFire: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @IA_RifleFire()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""IA_RifleFire"",
    ""maps"": [
        {
            ""name"": ""Sound"",
            ""id"": ""a5decba9-b4b0-4a1a-81ea-0e3677f63539"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""eee864b5-81b5-458f-8105-e582f5b1bd27"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6fa01a8-c2b6-49ef-a6b0-a9fbc475d43c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Sound
        m_Sound = asset.FindActionMap("Sound", throwIfNotFound: true);
        m_Sound_Fire = m_Sound.FindAction("Fire", throwIfNotFound: true);
    }

    ~@IA_RifleFire()
    {
        UnityEngine.Debug.Assert(!m_Sound.enabled, "This will cause a leak and performance issues, IA_RifleFire.Sound.Disable() has not been called.");
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

    // Sound
    private readonly InputActionMap m_Sound;
    private List<ISoundActions> m_SoundActionsCallbackInterfaces = new List<ISoundActions>();
    private readonly InputAction m_Sound_Fire;
    public struct SoundActions
    {
        private @IA_RifleFire m_Wrapper;
        public SoundActions(@IA_RifleFire wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Sound_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Sound; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SoundActions set) { return set.Get(); }
        public void AddCallbacks(ISoundActions instance)
        {
            if (instance == null || m_Wrapper.m_SoundActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SoundActionsCallbackInterfaces.Add(instance);
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
        }

        private void UnregisterCallbacks(ISoundActions instance)
        {
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
        }

        public void RemoveCallbacks(ISoundActions instance)
        {
            if (m_Wrapper.m_SoundActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISoundActions instance)
        {
            foreach (var item in m_Wrapper.m_SoundActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SoundActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SoundActions @Sound => new SoundActions(this);
    public interface ISoundActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
}
