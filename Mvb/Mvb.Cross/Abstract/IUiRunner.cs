﻿using System;
using System.Collections.Specialized;

namespace Mvb.Cross.Abstract
{
    public interface IUiRunner
    {
        /// <summary>
        /// Execute action on UiThread
        /// </summary>
        /// <param name="action"></param>
        void Run(Action action);

        /// <summary>
        /// Execute action on UIThread
        /// </summary>
        /// <param name="action"></param>
        /// <param name="args"></param>
        void Run(Action<NotifyCollectionChangedEventArgs> action, NotifyCollectionChangedEventArgs args);
    }
}