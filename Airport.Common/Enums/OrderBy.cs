namespace Airport.Common.Enums
{
    public enum OrderBy
    {
        // By default it will sort by id (logic in Repository)
        Name = 0,
        Name_Desc,
        Birth_Date,
        Birth_Date_Desc,
        Experience,
        Experience_Desc,
        Price,
        Price_Desc,
        LifeTime,
        LifeTime_Desc,
        NumberOfPlaces,
        NumberOfPlaces_Desc,
        CarryingCapacity,
        CarryingCapacity_Desc,
        PlaneType, // Will group Planes by Type
        Flight, // Will group Departures, Tickets by Flight
        Arrival_Date,
        Arrival_Date_Desc,
        Departure_Date,
        Departure_Date_Desc,
        Stewardesses_Amount,
        Stewardesses_Amount_Desc
    }
}