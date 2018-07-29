namespace ClientLight.Model
{
    using System;

    using GalaSoft.MvvmLight;

    public class Age : ViewModelBase
    {
        public Age() { }

        private int _years;
        public int Years
        {
            get { return _years; }
            set { _years = value; }
        }

        private int _months;
        public int Months
        {
            get { return _months; }
            set { _months = value; }
        }

        private int _days;
        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }

        public Age(DateTime Bday)
        {
            Count(Bday);
        }

        public Age(DateTime Bday, DateTime Cday)
        {
            Count(Bday, Cday);
        }

        public Age(TimeSpan timeSpan)
        {
            Years = (int)(timeSpan.Days / 365.2425);
            Months = (int)(timeSpan.Days / 30.436875) % 12;
            Days = (int)(timeSpan.Days % 30.436875);
            // Days = (int)(timeSpan.Days - (timeSpan.Days / 30.436875));
        }

        public Age Count(DateTime Bday)
        {
            return Count(Bday, DateTime.Today);
        }

        public Age Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
                (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                  ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    Years = Cday.Year - Bday.Year;
                    Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        Years = Cday.Year - Bday.Year;
                        Months = 0;
                        Days = Cday.Day - Bday.Day;
                    }
                    else
                    {
                        Years = (Cday.Year - 1) - Bday.Year;
                        Months = 11;
                        Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                    }
                }
                else
                {
                    Years = (Cday.Year - 1) - Bday.Year;
                    Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                Years = 0;
                Months = 0;
                Days = 0;
            }

            return this;
        }
    }
}
