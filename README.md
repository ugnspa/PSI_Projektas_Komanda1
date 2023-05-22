# Architecture:
The project uses ASP.NET MVC architecture:

![Working-of-MVC-1024x686](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/cb46d63e-1b49-450d-8ae1-3dbb2d9a53cb)


The architecture consists of:
<ul>
<li>
  Views - where the user interacts
  </li>
<li>
  Controller - processes requests and sends responses to the view
  </li>
<li>
  Model - middleware for handling database entries (objects)
  </li>
<li>
  Repository - handles reading and writing to the database
  </li>
  </ul>
  
# How to run the project:

In the appsetings.json, at the "DbConnStr" line add your database login credentials:

![image](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/40f7903d-e9f8-46d9-aec6-f7d08fffc9d6)

Data source - database IP adress.
port - database PORT.
Initial Catalog - database name
User Id - username
Password - user password

In the appsettings.json file you must also add your PayPal API credentials, so that the item ordering works.

![image](https://github.com/ugnspa/PSI_Projektas_Komanda1/assets/25864361/4194b653-ec3b-4701-a903-fb64b66f5c43)
