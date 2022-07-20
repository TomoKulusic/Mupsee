# Mupsee - Movie proxy

# Project description and how does it work
Idea behind this project is to filter movies/trailers. First on the search page you search for the movie and when you open the movie you will get trailers for that movie. When you open search page first you will get latest movies, and than you can search for others using the filters. On search input there is a debouncer so everytime you change something the filter will pull data, same goes to changing some of the filters. When you opene the movie you can see some basic data about it and all trailers. You can add movie as favorite and access it in the favorites page. There is also contact page for sending email/request.

Idea for project design (this was the starting point, but it changed during the process)
![Movies Proxy Search Engine - Mupsee](https://user-images.githubusercontent.com/17182815/179998073-fb01e8cd-06f0-44ff-8c1d-46845d9ffb07.png)


# Ides on the way
For filtering the movies the idea was to use some sort of elastic search, but since we dont have dedicated movie database and we get data directly from the imbd api that idea seemed bit to complicated to implement at first. So i have decided to go with easier way and build simple filter for searching.

Youtube api/imbd api are in the mupsee project for purposes of this project, but if we decided to scale it and push it to production we could consider separating thoes two api into separate projects and deploy them as microservices.

In the future maybe considering to  build ML lib for searching similar movies by plot, genre etc.. and displaying them as suggested movies depending on your history/favorites.

Currently only youtube videos are cached, but in the future i might consider caching movies just to improve performance.

# How to run a project.

When you pull the repository in the API you need to setup your connection strings, email recipient and password, for dummy mails i have used https://ethereal.email/ it is simple 2 click mail generator, and you just put email and passwword into appsettings

For client you can just run it using npm start.
You can login into app using this data {username: Dummy, password: Dummy_user} there is no user database, therefo in this version there is no registration process you can simply login using this dummy data.

