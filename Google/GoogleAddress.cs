﻿using System;
using System.Linq;

namespace Geocoding.Google
{
	public class GoogleAddress : ParsedAddress
	{
		readonly GoogleAddressType type;
		readonly GoogleAddressComponent[] components;
		readonly bool isPartialMatch;
		readonly GoogleViewport viewport;

		public GoogleAddressType Type
		{
			get { return type; }
		}

		public GoogleAddressComponent[] Components
		{
			get { return components; }
		}

		public bool IsPartialMatch
		{
			get { return isPartialMatch; }
		}

		public GoogleViewport Viewport
		{
			get { return viewport; }
		}

		public GoogleAddressComponent this[GoogleAddressType type]
		{
			get { return Components.FirstOrDefault(c => c.Types.Contains(type)); }
		}

		public GoogleAddress(GoogleAddressType type, string formattedAddress, GoogleAddressComponent[] components, Location coordinates, GoogleViewport viewport, bool isPartialMatch)
			: base(formattedAddress, coordinates, "Google")
		{
			if (components == null)
				throw new ArgumentNullException("components");

			this.type = type;
			this.components = components;
			this.isPartialMatch = isPartialMatch;
			this.viewport = viewport;
		}

        // ParsedAddress Street Property
        public override string Street
        {
            get { return this[GoogleAddressType.StreetAddress] != null ? this[GoogleAddressType.StreetAddress].LongName : string.Empty; }
            set { base.Street = value; }
        }

        // ParsedAddress City Property
        public override string City
        {
            get { return this[GoogleAddressType.Locality] != null ? this[GoogleAddressType.Locality].LongName : string.Empty; }
            set { base.Country = value; }
        }

        // ParsedAddress County Property
        public override string County
        {
            get { return this[GoogleAddressType.AdministrativeAreaLevel2] != null ? this[GoogleAddressType.AdministrativeAreaLevel2].LongName : string.Empty; }
            set { base.County = value; }
        }

        // ParsedAddress State Property
        public override string State
        {
            get { return this[GoogleAddressType.AdministrativeAreaLevel1] != null ? this[GoogleAddressType.AdministrativeAreaLevel1].ShortName : string.Empty; }
            set { base.State = value; }
        }

        // ParsedAddress Country Property
        public override string Country
        {
            get { return this[GoogleAddressType.Country] != null ? this[GoogleAddressType.Country].LongName : string.Empty; }
            set { base.Country = value; }
        }

        // ParsedAddress PostCode Property
        public override string PostCode
        {
            get { return this[GoogleAddressType.PostalCode] != null ? this[GoogleAddressType.PostalCode].LongName : string.Empty; }
            set { base.PostCode = value; }
        }

        // ParsedAddress District Property
        public override string District
        {
            get { return this[GoogleAddressType.Neighborhood] != null ? this[GoogleAddressType.Neighborhood].LongName : string.Empty; }
            set { base.District = value; }
        }
	}
}