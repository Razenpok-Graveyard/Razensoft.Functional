﻿using Razensoft.Functional.Internal;
using System;
using System.Runtime.Serialization;

namespace Razensoft.Functional
{
    [Serializable]
    public partial struct Result : IResult, ISerializable
    {
        private readonly ResultCommonLogic<string> _logic;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        private Result(bool isFailure, string error)
        {
            _logic = new ResultCommonLogic<string>(isFailure, error);
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            _logic = ResultCommonLogic<string>.Deserialize(info);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => _logic.GetObjectData(info);
    }
}
