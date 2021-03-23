using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdater
{
    void Init();
    void SystemUpdate();
    void DeInit();
}
