using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTest : TModule
{
    public override void Register()
    {
        TAccessor<ModuleTest>.Instance().Register(gameObject.GetInstanceID(), this);
    }

    public override void Unregister()
    {
        TAccessor<ModuleTest>.Instance().Unregister(gameObject.GetInstanceID());
    }
}
