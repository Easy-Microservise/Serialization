﻿using System;
using EasyMicroservices.Serialization.Interfaces;

namespace EasyMicroservices.Serialization.Options
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializationOptionBuilder
    {
        private static Func<IBinarySerialization> _binarySerializationFunc;
        private static Func<ITextSerialization> _textSerializationFunc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        public static void UseTextSerialization(Func<ITextSerialization> func)
        {
            if (_textSerializationFunc != null)
                throw new Exception("You set UseTextSerialization once.");
            _textSerializationFunc = func;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        public static void UseBinarySerialization(Func<IBinarySerialization> func)
        {
            if (_binarySerializationFunc != null)
                throw new Exception("You set UseBinarySerialization once.");
            _binarySerializationFunc = func;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ITextSerialization GetTextSerialization()
        {
            if (_textSerializationFunc == null)
                throw new Exception("You did not set UseTextSerialization.");
            return _textSerializationFunc();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IBinarySerialization GetBinarySerialization()
        {
            if (_binarySerializationFunc != null)
                throw new Exception("You did not set UseBinarySerialization.");
            return _binarySerializationFunc();
        }
    }
}
