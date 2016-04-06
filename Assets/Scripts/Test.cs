using UnityEngine;
using System.Collections;

public class Test : BennyBroseph.Contextual.Singleton<MonoBehaviour>
{
    enum States { INIT, IDLE, }

    // Use this for initialization
    void Start()
    {
        BennyBroseph.FiniteStateMachine<States> FSM = new BennyBroseph.FiniteStateMachine<States>();
        FSM.PrintStates();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
