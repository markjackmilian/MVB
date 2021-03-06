// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Mvb.FakeContacts.Cocoa.App
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableView ContactsList { get; set; }

		[Outlet]
		AppKit.NSButton LoadContactsBtn { get; set; }

		[Outlet]
		AppKit.NSButton ShakeBtn { get; set; }

		[Outlet]
		AppKit.NSTextField SummaryLbl { get; set; }

		[Action ("LoadContactsClicked:")]
		partial void LoadContactsClicked (Foundation.NSObject sender);

		[Action ("ShakeNamesClicked:")]
		partial void ShakeNamesClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ContactsList != null) {
				ContactsList.Dispose ();
				ContactsList = null;
			}

			if (LoadContactsBtn != null) {
				LoadContactsBtn.Dispose ();
				LoadContactsBtn = null;
			}

			if (SummaryLbl != null) {
				SummaryLbl.Dispose ();
				SummaryLbl = null;
			}

			if (ShakeBtn != null) {
				ShakeBtn.Dispose ();
				ShakeBtn = null;
			}
		}
	}
}
