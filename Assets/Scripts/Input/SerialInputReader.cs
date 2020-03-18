using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.Serialization;
using UnityScript.Steps;

namespace Eurovision.Input
{
    /// <summary>
    /// Reads data from the Arduino
    /// Passes data to InputHandler when data is received
    /// </summary>
    public class SerialInputReader : InputReader
    { 
        [SerializeField] private string portName = "dev/cu.usbmodem141101";
        [SerializeField] private int baudRate = 9600;
        
        private SerialPort _serialPort;

        private void Start()
        {
            _serialPort = new SerialPort("/" + portName, baudRate);
            _serialPort.Open();
        }

        private void Update()
        {
            try
            {
                var data = int.Parse(_serialPort.ReadLine());
                ParseInput(data);
            }
            catch (System.Exception)
            {
                // we leave the catch empty on purpose. No action is need if the try fails
            }
        }
    }
}