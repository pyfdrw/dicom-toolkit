﻿namespace SimpleDICOMToolkit.ViewModels
{
    using Stylet;
    using StyletIoC;
    using System;

    public class CStoreViewModel : Screen, IDisposable
    {
        [Inject]
        public ServerConfigViewModel ServerConfigViewModel { get; private set; }

        [Inject]
        public CStoreFileListViewModel CStoreFileListViewModel { get; private set; }

        public CStoreViewModel()
        {
            DisplayName = "C-Store";
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();

            ServerConfigViewModel.Init(this);
        }

        public void Dispose()
        {
            // TODO
        }
    }
}
