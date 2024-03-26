using System.Collections.Generic;
namespace DateProject{

    public class Date {

        private ISystemDateProvider _provider;

        private int _year;
        private int _month;
        private int _day;

        public int Year {
            get {
                return _year;
            }
        }
        public int Month { 
            get { return _month;}
        }
        public string MonthName {
            get {
                switch(_month) {
                    case 1: return "January"; 
                    case 2: return "February"; 
                    case 3: return "March"; 
                    case 4: return "April"; 
                    case 5: return "May";
                    case 6: return "August";
                    case 7: return "September";
                    case 10: return "October";
                    case 11: return "November";
                    case 12: return "December";
                    default: return "Unknown"; 
                }
            }
        }
        public string MonthNameAbbrev {
            get {
                switch(_month) {
                    case 1: return "Jan"; 
                    case 2: return "Feb"; 
                    case 3: return "Mar"; 
                    default: return "Unknown"; 
                }
            }
        }

        public int Day {
            get {
                return _day;
            }
        }
        public Date() {
            _year=1900;
            _month=1;
            _day=1;
        }
        public Date(int year, int month, int day) {
            //you can only create a date this way
            if(year >= -9998 && year <= 9999) {
                _year=year;
            }
            else {
                throw new System.ArgumentOutOfRangeException("Year must be between -9998 and 9999.");
            }
            if (month >=1 && month <=12) {
                _month=month;
            }
            else {
                throw new System.ArgumentOutOfRangeException ("Month must be between 1 and 12.");
            }
            if(month==9 || month == 4 || month ==6 || month==11) {
                if(day >=1 && day <= 30) {
                    _day=day;
                }
                else {
                    throw new System.ArgumentOutOfRangeException("Day must be between 1 and 30.");
                }
            }
            else if(month==2) {
                if(day >=1 && day <= 28) {
                    _day=day;
                }
                else {
                    throw new System.ArgumentOutOfRangeException("Day must be between 1 and 28.");
                }
            }
            else {
                if(day >=1 && day <= 31) {
                    _day=day;
                }
                else {
                    throw new System.ArgumentOutOfRangeException("Day must be between 1 and 31.");
                }
            }

        _provider = new MySystemDateProvider();


            
        }
        public Date(int year, int month,int day, ISystemDateProvider provider ):this(year,month,day) {
            _provider=provider;
        }

        public override string ToString()
        {
            return $"{Year}-{Month}-{Day}";
        }
        public bool IsToday() {
            //System.DateTime today = System.DateTime.UtcNow;
            Date today = _provider.GetToday();
    
            
            if(this.Month == today.Month && this.Day == today.Day)
                return true;
            else
                return false; 
        }

            public bool IsToday(bool throwException) {
            //System.DateTime today = System.DateTime.UtcNow;
            Date today = _provider.GetToday();
    
            
            if(this.Month == today.Month && this.Day == today.Day)
                return true;
            else
                return false; 
        }
        public string WhatHolidayIsOnThisDay() {
            //assume this is an external dependency - code that you don't control or test
            //can't predict what these dates will be when writing tests
            HolidayProvider _holidayProvider = new HolidayProvider();
            List<Holiday> list = _holidayProvider.GetHolidays(Year);

            foreach(Holiday holiday in list) {
                //add code later to handle if two holidays are in the list for this day
                if(holiday.TheDate.Month == Month && holiday.TheDate.Day==Day)
                    return holiday.Name;
            }
            return null;

        }

        
        public Date AddOneMonth() {
             if(this.Month==12) {
                    return new Date(this.Year+1, 1, InvalidDayForMonth(1,this.Day)? MaxDayOfMonth(1):this.Day);
                }
             else return new Date(this.Year, this.Month+1,InvalidDayForMonth(this.Month+1,this.Day)? MaxDayOfMonth(this.Month+1):this.Day );

        }
        //add these private methods for help with validation - don't need to test, only need to test public facing methods

        
        private int MaxDayOfMonth(int month) {
            switch(month) {
                case 9: 
                case 4:
                case 6:
                case 11: return 30;
                case 2: return 28;
                default: return 31;
            }
        }
        private bool InvalidDayForMonth(int day, int month) {
            switch(month) {
                case 9: 
                case 4:
                case 6:
                case 11: if(day>30) return true;break;
                case 2: if(day>28) return true; break;
                default: if(day>31) return true;break;
            }
            return false;
        }



        


    }
    public interface ISystemDateProvider {
        public Date GetToday();
       
    }
    public class MySystemDateProvider:ISystemDateProvider {
        public Date GetToday() {
            System.DateTime now = System.DateTime.UtcNow;
            return new Date(now.Year,now.Month,now.Day);
        }
    }
}
