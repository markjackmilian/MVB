﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mvb.Cross;

namespace Mvb.Test.ViewModels
{
    public class TestVm : MvbBase
    {
        private string _test;

        private ObservableCollection<string> _testCollection;

        public TestVm()
        {
            this.TestCollection = new ObservableCollection<string>();
            this.InitBinder();
        }

        public string Test
        {
            get { return this._test; }
            set { this.SetProperty(ref this._test, value); }
        }

        public ObservableCollection<string> TestCollection
        {
            get { return this._testCollection; }
            set { this.SetProperty(ref this._testCollection, value); }
        }


        private bool _wait;

        public bool Wait
        {
            get { return this._wait; }
            set { SetProperty(ref _wait, value); }
        }

        public async Task LogTaskTest()
        {
            this.Wait = true;
            await Task.Delay(2000);
            this.Wait = false;
        } 
    }
}