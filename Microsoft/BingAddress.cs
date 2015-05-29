using System;

namespace Geocoding.Microsoft
{
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/ff701726.aspx
    /// </remarks>
	public class BingAddress : ParsedAddress
	{
		readonly string addressLine, adminDistrict, adminDistrict2, countryRegion, locality, postalCode;
		readonly EntityType type;
		readonly ConfidenceLevel confidence;

		public string AddressLine
		{
			get { return addressLine ?? ""; }
		}

		public string AdminDistrict
		{
			get { return adminDistrict ?? ""; }
		}

		public string AdminDistrict2
		{
			get { return adminDistrict2 ?? ""; }
		}

		public string CountryRegion
		{
			get { return countryRegion ?? ""; }
		}

		public string Locality
		{
			get { return locality ?? ""; }
		}

		public string PostalCode
		{
			get { return postalCode ?? ""; }
		}

		public EntityType Type
		{
			get { return type; }
		}

		public ConfidenceLevel Confidence
		{
			get { return confidence; }
		}

        // ParsedAddress Street Property
        public override string Street
        {
            get { return AddressLine; }
        }

        // ParsedAddress City Property
	    public override string City
	    {
	        get { return Locality; }
	    }

	    // ParsedAddress County Property
        public override string County
        {
            get { return AdminDistrict2 ; }
        }

        // ParsedAddress State Property
        public override string State
        {
            get { return AdminDistrict; }
        }

        // ParsedAddress Country Property
        public override string Country
        {
            get { return CountryRegion; }
        }

        // ParsedAddress PostCode Property
        public override string PostCode
        {
            get { return PostalCode; }
        }

		public BingAddress(string formattedAddress, Location coordinates, string addressLine, string adminDistrict, string adminDistrict2,
			string countryRegion, string locality, string postalCode, EntityType type, ConfidenceLevel confidence)
			: base(formattedAddress, coordinates, "Bing")
		{
			this.addressLine = addressLine;
			this.adminDistrict = adminDistrict;
			this.adminDistrict2 = adminDistrict2;
			this.countryRegion = countryRegion;
			this.locality = locality;
			this.postalCode = postalCode;
			this.type = type;
			this.confidence = confidence;
		}
	}
}