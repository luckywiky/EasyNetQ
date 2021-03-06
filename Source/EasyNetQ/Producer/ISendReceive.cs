﻿using System;
using System.Threading.Tasks;

namespace EasyNetQ.Producer
{
    public interface ISendReceive
    {
        /// <summary>
        /// Send a message to the specified queue
        /// </summary>
        /// <typeparam name="T">The type of message to send</typeparam>
        /// <param name="queue">The queue to send the message to</param>
        /// <param name="message">The message to send</param>
        void Send<T>(string queue, T message) where T : class;

        /// <summary>
        /// Receive a message from the specified queue
        /// </summary>
        /// <typeparam name="T">The type of message to receive</typeparam>
        /// <param name="queue">The queue to receive from</param>
        /// <param name="onMessage">The synchronous function that handles the message</param>
        /// <returns>Consumer cancellation. Call Dispose to stop consuming</returns>
        IDisposable Receive<T>(string queue, Action<T> onMessage) where T : class;

        /// <summary>
        /// Receive a message from the specified queue
        /// </summary>
        /// <typeparam name="T">The type of message to receive</typeparam>
        /// <param name="queue">The queue to receive from</param>
        /// <param name="onMessage">The asynchronous function that handles the message</param>
        /// <returns>Consumer cancellation. Call Dispose to stop consuming</returns>
        IDisposable Receive<T>(string queue, Func<T, Task> onMessage) where T : class;
    }
}