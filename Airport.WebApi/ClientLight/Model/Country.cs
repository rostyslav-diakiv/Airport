namespace ClientLight.Model
{
    public class Country
    {
        private string _countryCode;
        private string _countryName;

        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }

        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
    }
}
