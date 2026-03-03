namespace LaoAirline.Views

open Giraffe.ViewEngine
open LaoAirline.Models

module Pages =
    let layout pageTitle content =
        html [ _lang "en" ] [
            head [] [
                title [] [ str pageTitle ]
                meta [ _charset "UTF-8" ]
                meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                rawText "<link rel='stylesheet' href='https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&family=Outfit:wght@300;600&display=swap'>"
                style [] [
                    rawText """
                        :root {
                            --primary: #003087; 
                            --secondary: #D4AF37; 
                            --accent: #E31837; 
                            --white: #ffffff;
                            --glass: rgba(255, 255, 255, 0.1);
                        }
                        body {
                            margin: 0;
                            font-family: 'Outfit', sans-serif;
                            background-color: #f4f7f6;
                            color: #333;
                            overflow-x: hidden;
                        }
                        header {
                            background: linear-gradient(135deg, var(--primary) 0%, #001f5c 100%);
                            padding: 1.5rem 5%;
                            display: flex;
                            justify-content: space-between;
                            align-items: center;
                            box-shadow: 0 4px 15px rgba(0,0,0,0.2);
                        }
                        .logo {
                            color: var(--white);
                            font-size: 1.8rem;
                            font-weight: 700;
                            letter-spacing: 2px;
                            text-transform: uppercase;
                        }
                        .logo span { color: var(--secondary); }
                        
                        .content {
                            min-height: 80vh;
                        }

                        .hero {
                            background: linear-gradient(rgba(0, 48, 135, 0.7), rgba(0, 48, 135, 0.7)), url('https://images.unsplash.com/photo-1528127269322-539801943592?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80');
                            background-size: cover;
                            background-position: center;
                            height: 60vh;
                            display: flex;
                            flex-direction: column;
                            justify-content: center;
                            align-items: center;
                            color: white;
                            text-align: center;
                            padding: 0 20px;
                        }

                        .hero h1 { font-size: 3.5rem; margin-bottom: 10px; text-shadow: 2px 2px 10px rgba(0,0,0,0.5); }
                        .hero p { font-size: 1.2rem; opacity: 0.9; }

                        .search-box {
                            background: rgba(255, 255, 255, 0.95);
                            backdrop-filter: blur(10px);
                            padding: 30px;
                            border-radius: 20px;
                            box-shadow: 0 20px 40px rgba(0,0,0,0.1);
                            margin-top: -80px;
                            width: 80%;
                            max-width: 1000px;
                            display: grid;
                            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
                            gap: 20px;
                            z-index: 10;
                            border: 1px solid rgba(255,255,255,0.3);
                        }

                        .input-group { display: flex; flex-direction: column; }
                        .input-group label { font-size: 0.8rem; font-weight: 600; color: #666; margin-bottom: 5px; text-transform: uppercase; }
                        .input-group input, .input-group select {
                            padding: 12px;
                            border: 2px solid #eee;
                            border-radius: 10px;
                            font-size: 1rem;
                            outline: none;
                            transition: border-color 0.3s;
                        }
                        .input-group input:focus { border-color: var(--primary); }

                        .btn-search {
                            background: var(--secondary);
                            color: #000;
                            border: none;
                            padding: 15px 30px;
                            border-radius: 10px;
                            font-weight: 700;
                            cursor: pointer;
                            transition: transform 0.2s, background 0.3s;
                            text-transform: uppercase;
                            align-self: flex-end;
                        }
                        .btn-search:hover { transform: translateY(-3px); background: #c5a02c; }

                        .flight-card {
                            background: white;
                            border-radius: 15px;
                            padding: 20px;
                            margin: 20px 0;
                            box-shadow: 0 5px 15px rgba(0,0,0,0.05);
                            display: flex;
                            justify-content: space-between;
                            align-items: center;
                            border-left: 5px solid var(--primary);
                        }
                    """
                ]
            ]
            body [] [
                header [] [
                    div [ _class "logo" ] [ str "Lao"; span [] [ str "Airlines" ] ]
                    div [ _class "nav" ] []
                ]
                div [ _class "content" ] content
                footer [ _style "background: #111; color: white; padding: 40px; text-align: center; margin-top: 100px;" ] [
                    str "© 2026 Lao Airlines - Ticket Selling System"
                ]
            ]
        ]

    let homePage () =
        layout "Lao Airlines | Fly with Excellence" [
            div [ _class "hero" ] [
                h1 [] [ str "The Jewel of Southeast Asia" ]
                p [] [ str "Experience the warm hospitality and unmatched service of Laos." ]
            ]
            div [ _style "display: flex; justify-content: center;" ] [
                form [ _class "search-box"; _method "GET"; _action "/search" ] [
                    div [ _class "input-group" ] [
                        label [] [ str "From" ]
                        select [ _name "origin" ] [
                            option [ _value "VTE" ] [ str "Vientiane (VTE)" ]
                        ]
                    ]
                    div [ _class "input-group" ] [
                        label [] [ str "To" ]
                        select [ _name "destination" ] [
                            option [ _value "PKZ" ] [ str "Pakse (PKZ)" ]
                            option [ _value "XKH" ] [ str "Xieng Khouang (XKH)" ]
                            option [ _value "LPQ" ] [ str "Luang Prabang (LPQ)" ]
                            option [ _value "XAY" ] [ str "Xayaboury (XAY)" ]
                        ]
                    ]
                    div [ _class "input-group" ] [
                        label [] [ str "Departure" ]
                        input [ _type "date"; _name "date" ]
                    ]
                    div [ _class "input-group" ] [
                        label [] [ str "Class" ]
                        select [ _name "fclass" ] [
                            option [ _value "Economy" ] [ str "Economy ($100)" ]
                            option [ _value "Business" ] [ str "Business ($500)" ]
                        ]
                    ]
                    button [ _type "submit"; _class "btn-search" ] [ str "Search Flights" ]
                ]
            ]
        ]

    let flightItem (f: Flight) =
        div [ _class "flight-card" ] [
            div [] [
                h3 [] [ str (f.Origin + " -> " + f.Destination) ]
                p [] [ str ("Class: " + f.Class.ToString() + " | Departure: " + f.Departure) ]
            ]
            div [ _style "text-align: right;" ] [
                div [ _style "font-size: 1.5rem; font-weight: 700; color: var(--primary);" ] [ str ("$" + f.Price.ToString()) ]
                button [ _class "btn-search"; _style "padding: 8px 15px; font-size: 0.8rem; margin-top: 10px;" ] [ str "Book Now" ]
            ]
        ]

    let resultsPage (flights: Flight list) =
        layout "Flight Results | Lao Airlines" [
            div [ _style "padding: 50px 5%; max-width: 800px; margin: 0 auto;" ] [
                h2 [] [ str "Available Flights" ]
                
                if List.isEmpty flights then
                    p [] [ str "No flights found for your selection." ]
                else
                    let flightHtmlElements = List.map flightItem flights
                    yield! flightHtmlElements
                
                a [ _href "/"; _style "display: inline-block; margin-top: 30px; color: var(--primary); text-decoration: none; font-weight: 600;" ] [ str "<- Back to Search" ]
            ]
        ]
