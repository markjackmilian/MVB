﻿using System;
using Foundation;
using Mvb.Core.Abstract;
using Mvb.Core.Args;

namespace Mvb.FakeContacts.Cocoa.App
{
	public class MacOsUiRunner : NSObject, IUiRunner
	{
		public void Run(Action action)
		{
			base.InvokeOnMainThread(action);
		}

		public void Run(Action<MvbCollectionUpdateArgs> action, MvbCollectionUpdateArgs args)
		{
			base.InvokeOnMainThread(() => { action.Invoke(args); });
		}
	}
}
