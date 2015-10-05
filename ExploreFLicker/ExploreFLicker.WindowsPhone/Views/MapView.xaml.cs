﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ExploreFlicker.Common;
using ExploreFlicker.Controls;


namespace ExploreFlicker.Views
{

    public sealed partial class MapView : ExtendedPage
    {
        public MapView()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(object sender, LoadStateEventArgs e)
        {
            base.LoadState(sender, e);
        }
    }
}
