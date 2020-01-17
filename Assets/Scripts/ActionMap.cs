using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Eurovision.Input
{
    /// <summary>
    /// maps serial input to ingame actions
    /// </summary>
    public class ActionMap : MonoBehaviour
    {
        private readonly Dictionary<int, string> _actionMap = new Dictionary<int, string>()
        {
            {11, "Knop 1 Boom!"},
            {21, "Knop 2 Boom!"}
        };

        public void HandleInputData(int data)
        {
            //print(actionMap[data]);
            print(_actionMap[data]);
        }
    }
}