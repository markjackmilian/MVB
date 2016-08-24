﻿using System;
using System.Collections.Specialized;
using DryIoc;
using Mvb.Core.Args;
using Mvb.FakeContacts.ModelBinders;
using UIKit;

namespace Mvb.FakeContacts.iOS.App
{
	public partial class ViewController : UIViewController
	{
		private ContactsSummaryModelBinders _contactSummaryMb;
		private ContactsModelBinders _contactsMb;


		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.ContactList.RowHeight = UITableView.AutomaticDimension;
			this.ContactList.EstimatedRowHeight = 80;


			//Get used binders for this view
			this._contactSummaryMb = AppDelegate.Ioc.Resolve<ContactsSummaryModelBinders>();
			this._contactsMb = AppDelegate.Ioc.Resolve<ContactsModelBinders>();
			//------------------------------

			//TableDataSource
			var dataSource = new ContactsTableDataSource(this._contactsMb.Contacts,this.ContactList);
			this.ContactList.Source = dataSource;

			//INit Binders
			this.InitModelBinders();
		}

		partial void ShakeNamesBtnTouchDown(UIButton sender)
		{
			this._contactsMb.ShakeNames();
		}

		partial void LoadBtnTouchDown(UIButton sender)
		{
			this._contactsMb.LoadContacts();
		}

		void InitModelBinders()
		{
			//Actions for 'IsBusy'
			this._contactsMb.Binder.AddAction<ContactsModelBinders>(b => b.IsBusy, () =>
				{
				this.SummaryLbl.BackgroundColor = this._contactsMb.IsBusy ? UIColor.Red : UIColor.White;
					this.LoadBtn.Enabled = !this._contactsMb.IsBusy;
				});

			//Actions for 'Summary'
			this._contactSummaryMb.Binder.AddAction<ContactsSummaryModelBinders>(b => b.Summary, () =>
			  {
				  this.SummaryLbl.Text = this._contactSummaryMb.Summary;
			  });
			//MANUAL RUN FOR FIRST ASSIGNMENT
			this._contactSummaryMb.Binder.Run<ContactsSummaryModelBinders>(b => b.Summary);

			//Actions for 'Contacts' collections
			this._contactsMb.Binder.AddActionForCollection<ContactsModelBinders>(b => b.Contacts, args =>
			  {
				  if (args.MvbUpdateAction == MvbUpdateAction.CollectionChanged)
				  {
					  switch (args.NotifyCollectionChangedEventArgs.Action)
					  {
						  case NotifyCollectionChangedAction.Add:
								ContactList.ReloadData();

							  this.LoadBtn.Hidden = true;
							this.ShakeBtn.Hidden = false;
							  break;
						  case NotifyCollectionChangedAction.Remove:
							  break;
						  case NotifyCollectionChangedAction.Replace:
							  break;
						  case NotifyCollectionChangedAction.Move:
							  break;
						  case NotifyCollectionChangedAction.Reset:
							  break;
						  default:
							  throw new ArgumentOutOfRangeException();
					  }
				  }
				  else if (args.MvbUpdateAction == MvbUpdateAction.ItemChanged)
				  {
					this.ContactList.ReloadData();
				  }
			  });


		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
