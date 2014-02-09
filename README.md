SFMovieLocations
================
## About ##
http://kh-sfmovielocations.azurewebsites.net/

SFMovieLocations is a web application that shows on a map where movies have been filmed in San Francisco.  The user is able to filter the view by auto-completion search on movie title.  

* GET: http://kh-sfmovielocations.azurewebsites.net/SFMovieLocations/
* GET: http://kh-sfmovielocations.azurewebsites.net/SFMovieLocations/MovieLocations/{id}
* GET: http://kh-sfmovielocations.azurewebsites.net/SFMovieLocations/MovieTitles?title={title}
* GET: http://kh-sfmovielocations.azurewebsites.net/SFMovieLocations/Search?prefix={prefix}&count={count}

## Data Preparation ##
San Francisco film location data is freely available from sfgov:

https://data.sfgov.org/Arts-Culture-and-Recreation-/Film-Locations-in-San-Francisco/yitu-d5am

Data processing was required to transform free-text location strings into coordinates, to be used for building google map markers with the film location data.  This was done via:
* best effort location string normalization by parsing valid location data from certain patterns observed and some manual editing.  The location strings are provided in a variety of formats, i.e. address, landmark, street intersection, single street, parallel streets, sf district, etc, where either one or two of these (second is written in parenthesis) is provided.  In the case of the latter, the more specific location (i.e., address over district) is selected for lookup.
* leveraging Google's Geocoding API to translate these locations into coordinates.

## Design Overview ##
C# and SqlServer/T-SQL are currently my most comfortable coding language and database/query language, respectively.  Given the limited timeframe for this prototype, I decided to build this project using ASP.NET MVC + Web API and host it on Windows Azure, taking advantage of their free trial (whereas several other .NET hosting solutions I looked into would have been costly or not comprehensive enough).  Aside from C#/SqlServer/T-SQL, however, every other technology was new or relatively new to me at the start of this project (frontend development, Windows Azure hosting for Sql Server + website, git, Google geocoding + map apis, and ASP.NET MVC + Web API).  What a fun adventure!

## Assumptions & Limitations ##
Given the time limitation and prototype nature of this project, the following were excluded:
* additional work on location string normalization for coordinate lookup, which would have resulted in higher film location coverage.  Only those film locations where coordinate lookup succeeded are present on the map.
* JSON serializer overriding.  Instead, I leveraged James Newton-King's JsonNetResult for pretty printing JSON output.  Not functionally required for this project, but vastly improves readability of the JSON output.  Reference: http://james.newtonking.com/archive/2008/10/16/asp-net-mvc-and-json-net
* unit tests 
* thorough documentation
* production monitoring + support

## Disclaimer ##
This is a prototype and is not supported.




