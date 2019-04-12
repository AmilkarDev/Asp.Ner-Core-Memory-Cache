# Asp.Net-Core-Memory-Cache
A simple application developed with asp.NET core MVC , demostrating the usage of InMemoryCache in .Net core
# Steps to launch the App 
1. run dotnet restore command
2. run the application and learn the explanation of the results
# Tools to install
You need Visual studio 2017/VS code , asp.Core 2.1 SDK .  

![visual studio code logo](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXbVDcQP7ha9Xu8eH9ldBItvcDubOoR6LEItMIpnFcYB4wWOCg "Logo vs code")
![visual studio 2017 logo](https://static.techspot.com/images2/downloads/topdownload/2016/06/visualstudio.png "logo visual studio 2017")
![ASP.net core logo](https://efficientuser.files.wordpress.com/2018/08/aspnetcore.png "Logo asp.Net Core")

# Summary
1. In-Memory Caching works well with small-mid sized applications.
2. Cache should have fallback mechanism to fetch data and not completely rely on cache for data.
3. Limiting caching size is crucial for limiting the use of memory and so it is important to define the life of a cache item using different ways of cache expiration techniques.
