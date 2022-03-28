using System.Text.RegularExpressions;

namespace FakeXieCheng.API.ResourceParameters
{
    public class TouristRouteResourceParameters
    {
        public string Keyword { get; set; }

        private string _rating;
        public string Rating
        {
            get { return _rating; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Regex regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");

                    Match match = regex.Match(value);

                    if (match.Success)
                    {
                        RatingOperator = match.Groups[1].Value;
                        RatingValue = int.Parse(match.Groups[2].Value);
                    }
                }
                _rating = value;
            }
        }

        public string RatingOperator { get; set; }
        public int? RatingValue { get; set; }


        private int _pageNumber = 1;
        public int PageNumber
        {
            get
            {

                return _pageNumber;
            }
            set
            {
                if (value >= 1)
                {
                    _pageNumber = value;
                }
            }
        }

        private int _pageSize = 10;
        const int maxPageSize = 50;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if(value >= 1)
                {
                    _pageSize = value > maxPageSize ? maxPageSize : value;
                }
            }
        }
    }
}
