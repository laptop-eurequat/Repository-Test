﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Service
{
    public class MessageResponseHistory<T>
    {
        private Dictionary<String,T> _responseHistory;

        public MessageResponseHistory()
        {
            _responseHistory = new Dictionary<String, T>();
        }
        public bool IsAUniqueRequest(string correlationId)
        {
            return !_responseHistory.ContainsKey(correlationId);
        }
        public void LogResponse(string correlationId, T response)
        {
            if(_responseHistory.ContainsKey(correlationId))
                _responseHistory[correlationId]=response;
            else
                _responseHistory.Add(correlationId,response);
        }
        public T RetrievePreviousResponseFor(string correlationId)
        {
            return _responseHistory[correlationId];
        }
    }
}
