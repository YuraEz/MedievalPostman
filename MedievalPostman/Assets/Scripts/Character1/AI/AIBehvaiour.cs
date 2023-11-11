using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehvaiour : MonoBehaviour
{
    public virtual void OnInit() { }
    public virtual bool OnCheckEnter() { return true; }
    public virtual void OnEnterLogic() { }
    public virtual void OnUpdateLogic() { }
}

