# Mupsee - Movie proxy

# Project description and how does it work
The idea behind this project is to filter movies/trailers. First, on the search page, search for the movie and when you open the movie you will get trailers for that movie. When you open the search page first you will get the latest movies, and then you can search for others using the filters. On search input, there is a debouncer so every time you change something the filter will pull data, the same goes for changing some of the filters. When you open the movie you can see some basic data about it and all trailers. You can add a movie as a favorite and access it on the favorites page. There is also a contact page for sending emails/requests. On the details page below movie trailers, you will see Twitter/facebook/LinkedIn share buttons.

Idea for project design (this was the starting point, but it changed during the process)
![Movies Proxy Search Engine - Mupsee](https://user-images.githubusercontent.com/17182815/179998073-fb01e8cd-06f0-44ff-8c1d-46845d9ffb07.png)


# Ideas on the way
For filtering the movies the idea was to use some sort of elastic search, but since we don't have a dedicated movie database and we get data directly from the IMBD API that idea seemed a bit too complicated to implement at first. So I have decided to go with the easier way and build a simple filter for searching.

Youtube API/IMBD  API are in the mupsee project for purposes of this project, but if we decided to scale it and push it to production we could consider separating those two APIs into separate projects and deploying them as microservices.

In the future maybe considering to build ML lib for searching similar movies by plot, genre, etc.. and displaying them as suggested movies depending on your history/favorites.

Currently, only youtube videos are cached, but in the future, I might consider caching movies just to improve performance.

# How to run

When you pull the repository in the API you need to set up your database connection strings, email recipient, and password, for dummy mails I have used https://ethereal.email/ it is a simple 2-click mail generator, and you just put email and password in appsettings file

Client page
- npm i --legacy-peer-deps 
- npm start

You can log in to the app using this data {username: Dummy, password: Dummy_user} there is no user database, therefore in this version, there is no registration process you can simply log in using this dummy data.

