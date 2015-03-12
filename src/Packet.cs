using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeLibrary
{
    public class Packet
    {
        private string _command;
        private bool _containsError;
        private string _errorMessage;
        private string[] _arguments;

        public string Command
        {
            get{return _command;}
            set{_command = value;}
        }
        public bool ContainsError
        {
            get { return _containsError; }
            set { _containsError = value; }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public string[] Arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
        }

    }
}
