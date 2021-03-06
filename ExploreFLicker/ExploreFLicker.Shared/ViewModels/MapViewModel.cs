﻿using System;
using System.Collections.Generic;
using System.Text;
#if WINDOWS_PHONE_APP
using Windows.Devices.Geolocation;
#else
using Bing.Maps;
#endif
using Windows.Foundation;
using ExploreFlicker.Common;
using ExploreFlicker.Models.Response;

namespace ExploreFlicker.ViewModels
{
    public class MapViewModel : BindableBase
    {
        #region properties
        private Photo _photo;
        /// <summary>
        /// Selected photo which will be used to showi pushpin on map.
        /// </summary>
        public Photo Photo
        {
            get { return _photo; }
            set
            {
                if (SetProperty(ref _photo, value))
                {
#if WINDOWS_PHONE_APP
                    OnPropertyChanged(@"Geopoint");
#else
                    OnPropertyChanged(@"Location");

#endif
                }
            }
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Represents location of photo on map.
        /// </summary>
        public Geopoint Geopoint
        {
            get
            {
                if (Photo == null) return new Geopoint(new BasicGeoposition());

                var geopoint = new Geopoint(new BasicGeoposition()
                {
                    Longitude = Photo.Longitude,
                    Latitude = Photo.Latitude
                });
                return geopoint;
            }
        }
#else
        /// <summary>
        /// Represents location of photo on map.
        /// </summary>
        public Location Location
        {
            get
            {
                if (Photo == null) return new Location(0, 0);

                var location = new Location(new Location()
                {
                    Longitude = Photo.Longitude,
                    Latitude = Photo.Latitude
                });
                return location;
            }
        }
#endif

        /// <summary>
        /// It is used to normalize the anchor point of pushpin.
        /// It can't be used directly in xaml, as there is a bug in the winrt map control.
        /// </summary>
        public Point Anchor
        {
            get { return new Point(0.5, 1); }
        }
        #endregion
    }
}
