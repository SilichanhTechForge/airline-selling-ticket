namespace LaoAirline.Models

type FlightClass = 
    | Economy 
    | Business
    
type Flight = {
    Id : string
    Origin : string
    Destination : string
    Departure : string
    Price : int
    Class : FlightClass
}

type BookingRequest = {
    FlightId : string
    PassengerName : string
    Email : string
}
