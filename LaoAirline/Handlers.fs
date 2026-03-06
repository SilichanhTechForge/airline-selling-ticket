namespace LaoAirline.Handlers

open Microsoft.AspNetCore.Http
open Giraffe
open LaoAirline.Models
open LaoAirline.Views

module AppHandlers =
    
    let allFlights = [
        { Id = "1"; Origin = "VTE"; Destination = "PKZ"; Departure = "Tomorrow"; Price = 100; Class = Economy }
        { Id = "2"; Origin = "VTE"; Destination = "PKZ"; Departure = "Tomorrow"; Price = 500; Class = Business }
        { Id = "3"; Origin = "VTE"; Destination = "XKH"; Departure = "In 2 days"; Price = 100; Class = Economy }
        { Id = "4"; Origin = "VTE"; Destination = "XKH"; Departure = "In 2 days"; Price = 500; Class = Business }
        { Id = "5"; Origin = "VTE"; Destination = "LPQ"; Departure = "Tomorrow"; Price = 100; Class = Economy }
        { Id = "6"; Origin = "VTE"; Destination = "LPQ"; Departure = "Tomorrow"; Price = 500; Class = Business }
        { Id = "7"; Origin = "VTE"; Destination = "XAY"; Departure = "In 3 days"; Price = 100; Class = Economy }
        { Id = "8"; Origin = "VTE"; Destination = "XAY"; Departure = "In 3 days"; Price = 500; Class = Business }
    ]

    let home (next : HttpFunc) (ctx : HttpContext) =
        let htmlContent = Pages.homePage()
        htmlView htmlContent next ctx

    let search (next : HttpFunc) (ctx : HttpContext) =
        let destReq = ctx.Request.Query.["destination"].ToString()
        let classReq = ctx.Request.Query.["fclass"].ToString()
        
        let requestedClass = 
            if classReq = "Business" then
                Business
            else
                Economy

        let filteredFlights = 
            allFlights 
            |> List.filter (fun f -> f.Destination = destReq)
            |> List.filter (fun f -> f.Class = requestedClass)

        let htmlContent = Pages.resultsPage filteredFlights
        htmlView htmlContent next ctx

    let profile (next : HttpFunc) (ctx : HttpContext) =
        let dummyUser = { Name = "Sabaidee Traveler"; MemberId = "LA123456"; Tier = "Gold"; Points = 12500 }
        // Example: user has booked a couple of flights
        let userBookings = [ allFlights.[0]; allFlights.[2] ]
        let htmlContent = Pages.profilePage dummyUser userBookings
        htmlView htmlContent next ctx
